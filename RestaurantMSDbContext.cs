using Microsoft.EntityFrameworkCore; 
using System;
namespace RestaurantManagementSystem.Data
{
    public class ResaurantMSDbContext : DbContext
    {
        public ResaurantMSDbContext(DbContextOptions<ResaurantMSDbContext> options) : base(options)
        {
        }

        protected override OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

}