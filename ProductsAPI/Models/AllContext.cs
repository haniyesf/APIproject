using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProductsAPI.Models
{
    public class AllContext : DbContext
    {
        public AllContext() : base("MyConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AllContext, ProductsAPI.Migrations.Configuration>());
        }


        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}