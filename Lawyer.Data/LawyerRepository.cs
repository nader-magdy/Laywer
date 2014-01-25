using Lawyer.Core.Framework;
using Lawyer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Data
{
    public class LawyerRepository : Repository
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            MapEntity<Lawyer.Model.Lawyer>(modelBuilder, "Lawyer");
            MapEntity<Case>(modelBuilder, "Case");
            MapEntity<Session>(modelBuilder, "Session");
            MapEntity<Court>(modelBuilder, "Court");
            MapEntity<Circle>(modelBuilder, "Circle");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Lawyer.Model.Lawyer> Lawyers
        {
            get
            {
                return GetAsDbSet<Lawyer.Model.Lawyer>();
            }
        }

        public DbSet<Court> Courts
        {
            get
            {
                return GetAsDbSet<Court>();
            }
        }
    }
}
