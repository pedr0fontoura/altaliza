using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Altaliza.Domain.Entities;

namespace Altaliza.Infra.Mapping
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("vehicles");

            builder.HasKey(vehicle => vehicle.Id);

            builder.Property(vehicle => vehicle.Name)
                .HasConversion(name => name.ToString(), name => name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            builder.Property(vehicle => vehicle.Stock)
                .IsRequired()
                .HasColumnName("Stock");

            builder.Property(vehicle => vehicle.Image)
                .HasConversion(name => name.ToString(), name => name)
                .IsRequired()
                .HasColumnName("Image")
                .HasColumnType("varchar(256)");

            builder.Property(vehicle => vehicle.Rent1Day)
                .IsRequired()
                .HasColumnName("Rent1Day");

            builder.Property(vehicle => vehicle.Rent7Day)
                .IsRequired()
                .HasColumnName("Rent7Day");

            builder.Property(vehicle => vehicle.Rent15Day)
                .IsRequired()
                .HasColumnName("Rent15Day");

            builder.HasOne(vehicle => vehicle.Category)
                .WithMany(vehicleCategory => vehicleCategory.Vehicles)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}