using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pill.Model
{
    class DataContext : DbContext
    {
        public DataContext() : base("name=ITI")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new EmployeeDataConfiguration());
            // modelBuilder.Entity<Project>().HasKey<int>(s => s.ID);
        }

        public DbSet<Fat> Pills { get; set; }
        public DbSet<Item> items { get; set; }

        //public DbSet<PillItems> PillItems { get; set; }
    }
}
