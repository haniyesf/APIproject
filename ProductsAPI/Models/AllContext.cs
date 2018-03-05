using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProductsAPI.Models
{
    public class AllContext :DbContext
    {
        public AllContext() : base("MyConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AllContext, ProductsAPI.Migrations.Configuration>());
        }


        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Factor> Factor { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Region> Region { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}