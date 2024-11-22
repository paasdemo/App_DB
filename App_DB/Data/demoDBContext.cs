using App_DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace App_DB.Data
{
    public class demoDBContext:DbContext
    {
        public demoDBContext(DbContextOptions<demoDBContext> options):base(options)
            { 
        }

        public DbSet<Userid> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Procate> Processes { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Orderdetail> Orderdetails { get; set; }
        public DbSet<Cartdetail> Cartsdetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Userid>().ToTable("userid");
            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<Procate>().ToTable("Procate");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<Orderdetail>().ToTable("Orderdetail");
            modelBuilder.Entity<Cartdetail>().ToTable("Cartdetail");
            modelBuilder.Entity<Cart>().ToTable("Cart");

        }
    }
}
