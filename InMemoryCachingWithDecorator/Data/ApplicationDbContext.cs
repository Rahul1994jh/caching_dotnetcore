using Microsoft.EntityFrameworkCore;
using InMemoryCachingWithDecorator.Entities;
using Bogus;

namespace InMemoryCachingWithDecorator.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Vehicle>? Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var id = 1;

            var vehicle = new Faker<Vehicle>()
                .RuleFor(v => v.Id, f => id++)
                .RuleFor(v => v.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(v => v.Model, f => f.Vehicle.Model())
                .RuleFor(v => v.Type, f => f.Vehicle.Type())
                .RuleFor(v => v.Fuel, f => f.Vehicle.Fuel())
                .RuleFor(v => v.Vin, f => f.Vehicle.Vin());

            modelBuilder.Entity<Vehicle>().HasData(vehicle.GenerateBetween(500, 500));
        }
    }
}
