using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Data
{
    public class Context : DbContext
    {
        private readonly IConfiguration _config;
        //public Context(DbContextOptions<Context> options) : base(options) { }
        public Context(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Discount>(x => x.HasIndex(i => i.Type).IsUnique());
            modelBuilder.Entity<Customer>(x => x.HasIndex(i => i.Name).IsUnique());
            modelBuilder.Entity<Discount>().HasData(
                new Discount
                {
                    Id = 1,
                    Type = "Groceries",
                    DiscountPercentage = 0,
                    DateAdded = DateTime.Now
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        public virtual DbSet<Customer> Customers { set; get; }
        public virtual DbSet<Invoice> Invoices { set; get; }
        public virtual DbSet<Discount> Discounts { set; get; }
    }
}
