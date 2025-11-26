using Microsoft.EntityFrameworkCore; 
using System;
namespace RestaurantManagementSystem.Data
{
    public class RestaurantMSDbContext : DbContext
    {
        public RestaurantMSDbContext(DbContextOptions<RestaurantMSDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

}