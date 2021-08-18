using System;
using Microsoft.EntityFrameworkCore;
using Altaliza.Domain.Entities;
using Altaliza.Infra.Mapping;
using Altaliza.Infra.Config;

namespace Altaliza.Infra.Context
{
    public class MySqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databaseConfig = new DatabaseConfiguration{
                Server = "localhost",
                Port = 3306,
                User = "root",
                Password = "admin",
                Database = "altaliza"
            };

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

            optionsBuilder.UseMySql(databaseConfig.ToMySqlConnectionString(), serverVersion);
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
