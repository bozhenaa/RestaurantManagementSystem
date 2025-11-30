using Microsoft.EntityFrameworkCore; 
using System;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Data
{
    public class RestaurantMSDbContext : DbContext
    {
        public RestaurantMSDbContext(DbContextOptions<RestaurantMSDbContext> options) : base(options)
        {
        }

        public DbSet<User>Users { get; set; }
        public DbSet<PasswordToken> PasswordTokens { get; set; }
        public DbSet<RestaurantTable> RestaurantTables { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

}