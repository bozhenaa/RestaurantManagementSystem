using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Data
{
    public class RestaurantMSDbContext : DbContext
    {
        public RestaurantMSDbContext(DbContextOptions<RestaurantMSDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PasswordToken> PasswordTokens { get; set; }
        public DbSet<RestaurantTable> RestaurantTables { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MenuItemIngredient> MenuItemIngredients { get; set; }

        public DbSet<OnlineOrder> OnlineOrders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservedTables> ReservedTables { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Menu>()
                .HasMany(m => m.MenuItems)
                .WithMany(mi => mi.Menus)
                .UsingEntity(j => j.ToTable("MenuMenuItems"));

            modelBuilder.Entity<ReservedTables>()
                .HasKey(rt => new { rt.ReservationId, rt.RestaurantTableId });

            
            modelBuilder.Entity<MenuItemIngredient>()
                .HasOne(mii => mii.MenuItem)
                .WithMany(mi => mi.MenuItemIngredients)
                .HasForeignKey(mii => mii.MenuItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MenuItemIngredient>()
                .HasOne(mii => mii.Ingredient)
                .WithMany(i => i.MenuItemIngredients)
                .HasForeignKey(mii => mii.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);
        
            modelBuilder.Entity<ReservedTables>()
                .HasOne(rt => rt.Reservation)
                .WithMany(r => r.ReservedTables)
                .HasForeignKey(rt => rt.ReservationId);

            modelBuilder.Entity<ReservedTables>()
                .HasOne(rt => rt.RestaurantTable)
                .WithMany() 
                .HasForeignKey(rt => rt.RestaurantTableId);
        }
    }
}
