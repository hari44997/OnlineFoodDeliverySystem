using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineFoodDeliverySystem;

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

    }
}
