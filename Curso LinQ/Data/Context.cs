using LinqExample;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleLinq.Data
{
    public class Context : DbContext
    {
        public Context() : base("MyDb")
        { 
        
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var initializer = new SqliteCreateDatabaseIfNotExists<Context>(modelBuilder);

            Database.SetInitializer(initializer);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<PersonEntity> Persons { get; set; }
    }
}
