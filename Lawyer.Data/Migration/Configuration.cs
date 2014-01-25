using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Data.Migration
{
    public sealed class Configuration : DbMigrationsConfiguration<LawyerRepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migration";
            ContextKey = "Lawyer.Data";
        }
    }
}
