using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineFoodDeliverySystem;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {
        }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            {
                IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }   
        
        
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Agent> Agents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Customer-Order Relationship
            modelBuilder.Entity<Customer>()
                .HasMany(o => o.Orders)
                .WithOne(c => c.Customer)
                .HasForeignKey(o => o.CustomerID);

            //Restaurant and MenuItem
            modelBuilder.Entity<Restaurant>()
                .HasMany(m => m.MenuItems)
                .WithOne(r => r.Restaurant)
                .HasForeignKey(m => m.RestaruntID)
                .HasPrincipalKey(r => r.RestaurantID);
            //Order and payment
            modelBuilder.Entity<Order>()
                .HasOne(p => p.Payments)
                .WithOne(o => o.Order)
                .Has()

           





        }


    }

}
