using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UsluzniObrt.Model;

namespace UsluzniObrt.Repository
{
    public class UsluzniObrtDbContext : IdentityDbContext
    {
        public UsluzniObrtDbContext() : base("UsluzniObrtDb")
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var user = modelBuilder.Entity<IdentityUser>()
                .ToTable("User");

            user.Property(u => u.Id).HasColumnName("UserId");
            user.HasMany(r => r.Roles).WithRequired().HasForeignKey(u => u.UserId);

            modelBuilder.Entity<IdentityUser>()
                .Ignore(u => u.AccessFailedCount)
                .Ignore(u => u.LockoutEnabled)
                .Ignore(u => u.LockoutEndDateUtc)
                .Ignore(u => u.PhoneNumberConfirmed)
                .Ignore(u => u.PhoneNumber)
                .Ignore(u => u.TwoFactorEnabled);

            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId })
                .ToTable("UserRole");

            var role = modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");

            role.Property(r => r.Id).HasColumnName("RoleId");
            role.HasMany(u => u.Users).WithRequired().HasForeignKey(r => r.RoleId);


        }

        public static UsluzniObrtDbContext Create()
        {
            return new UsluzniObrtDbContext();
        }
    }
}
