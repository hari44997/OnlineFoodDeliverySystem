using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineFoodDeliverySystem;

namespace OnlineFoodDeliverySystem
{
    public class MenuItemDbContext : DbContext
    {
        public MenuItemDbContext(DbContextOptions<MenuItemDbContext> options) : base(options)
        {
        }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            {
                IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        
        
         public DbSet<MenuItem> MenuItems { get; set; }


    }
}
