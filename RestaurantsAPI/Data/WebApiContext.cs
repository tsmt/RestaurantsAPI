using Microsoft.EntityFrameworkCore;
using RestaurantsAPI.Models;

namespace RestaurantsAPI.Data
{
    public class WebApiContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public WebApiContext(DbContextOptions<WebApiContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("Cities").HasKey(c => c.Id);
            modelBuilder.Entity<Restaurant>().ToTable("Restaurants").HasKey(r => r.Id);

            modelBuilder.Entity<Restaurant>()
                .HasOne(c => c.City)
                .WithMany(r => r.Restaurants)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
