using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Altaliza.Domain.Entities;

namespace Altaliza.Infra.Mapping
{
    public class CharacterVehicleMap : IEntityTypeConfiguration<CharacterVehicle>
    {
        public void Configure(EntityTypeBuilder<CharacterVehicle> builder)
        {
            builder.ToTable("characters_vehicles");

            builder.HasKey(characterVehicle => characterVehicle.Id);

            builder.Property(characterVehicle => characterVehicle.ExpirationDate)
                .IsRequired()
                .HasColumnName("ExpirationDate");

            builder.HasOne(characterVehicle => characterVehicle.Character)
                .WithMany(character => character.Vehicles);

            builder.HasOne(characterVehicle => characterVehicle.Vehicle)
                .WithMany(vehicle => vehicle.CharactersVehicles);
        }
    }
}
