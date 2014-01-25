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

   public class UserRepository : Repository
    {
       protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
       {
           MapEntity<User>(modelBuilder, "User");
           base.OnModelCreating(modelBuilder);
       }
       public DbSet<User> Users { get {
           return GetAsDbSet<User>();
       } }
    }
}
