using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Data
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        //{
        //    IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    string connectionString = configuration.GetConnectionString("DefaultConnection");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}


        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);

            //Customer-Order Relationship one to Many
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            //Restaurant and MenuItem (one-many)
            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Restaurant)
                .WithMany(r => r.MenuItems)
                .HasForeignKey(m => m.RestaurantID)
                .OnDelete(DeleteBehavior.Cascade);

            //Restaurant and order(one - to- many)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.RestaurantID)
                .OnDelete(DeleteBehavior.Cascade);

            //Order and OrderItem(one to many)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            //MenuItem and OrderItem (One - Many)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany(m => m.OrderItems)
                .HasForeignKey(oi => oi.ItemID)
                .OnDelete(DeleteBehavior.Restrict);

            //Order and Delivery (One - One)
            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Order)
                .WithOne(o => o.Delivery)
                .HasForeignKey<Delivery>(d => d.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            //Agent and Delivery (One - Many)
            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Agent)
                .WithMany(a => a.Deliveries)
                .HasForeignKey(d => d.AgentID)
                .OnDelete(DeleteBehavior.Restrict);

            //Order and Payment (One - One)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Payment>(p => p.OrderID)
                .OnDelete(DeleteBehavior.Cascade);
            //Roles and Users
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(r => r.RoleID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}