using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Core.Framework
{
    public  class Repository : DbContext, IRepository
    {
        protected const string DiscriminatorFieldName = "Discriminator";

        #region Constructors
        protected Repository() :base("Lawyer")
        { }

        protected Repository(DbConnection connection)
            : base(connection, false)
        { }

        #endregion

        #region Methods

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Maps the entity.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="toTable">To table.</param>
        /// <param name="discriminatorColumn">The discriminator column.</param>
        /// <param name="discriminatorValue">The discriminator value.</param>
        protected void MapEntity(DbModelBuilder modelBuilder, Type entityType, string toTable, string discriminatorColumn = DiscriminatorFieldName, string discriminatorValue = "")
        {
            var method =
              GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
              .FirstOrDefault(mi => mi.Name.StartsWith("MapEntity") && mi.IsGenericMethodDefinition);

            if (method == null)
            {
                return;
            }
            var genericMethod = method.MakeGenericMethod(entityType);

            genericMethod.Invoke(this, new object[] { modelBuilder, toTable, discriminatorColumn, discriminatorValue });
        }

        /// <summary>
        /// Maps the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="toTable">To table.</param>
        /// <param name="discriminatorColumn">The discriminator column.</param>
        /// <param name="discriminatorValue">The discriminator value.</param>
        protected void MapEntity<T>(
          DbModelBuilder modelBuilder, string toTable, string discriminatorColumn = DiscriminatorFieldName, string discriminatorValue = "")
          where T : class
        {
            /*
            modelBuilder.Entity<T>().Map(
              entity =>
              {
                  entity.ToTable(toTable);
              });
             * */

            var val = String.IsNullOrEmpty(discriminatorValue) ? typeof(T).Name : discriminatorValue;

            var config = modelBuilder.Entity<T>().Map(
              entity => entity.Requires(discriminatorColumn).HasValue(val).IsOptional());

            config.ToTable(toTable);
        }


        #endregion

        /// <summary>
        /// Gets as queryable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetAsQueryable<T>() where T : class
        {
            return Set<T>();
        }

        public DbSet<T> GetAsDbSet<T>() where T : class
        {
            return Set<T>();
        }
    }
}
