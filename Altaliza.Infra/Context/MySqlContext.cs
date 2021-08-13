using Altaliza.Domain.Entities;
using Altaliza.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Altaliza.Infra.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<VehicleCategory> VehiclesCategories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<CharacterVehicle> CharactersVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>(new CharacterMap().Configure);
            modelBuilder.Entity<VehicleCategory>(new VehicleCategoryMap().Configure);
            modelBuilder.Entity<Vehicle>(new VehicleMap().Configure);
            modelBuilder.Entity<CharacterVehicle>(new CharacterVehicleMap().Configure);
        }
    }
}
