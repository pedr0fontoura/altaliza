using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Altaliza.Domain.Entities;

namespace Altaliza.Infra.Mapping
{
    public class VehicleCategoryMap : IEntityTypeConfiguration<VehicleCategory>
    {
        public void Configure(EntityTypeBuilder<VehicleCategory> builder)
        {
            builder.ToTable("vehicles_categories");

            builder.HasKey(vehicleCategory => vehicleCategory.Id);

            builder.Property(vehicleCategory => vehicleCategory.Name)
                .HasConversion(name => name.ToString(), name => name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            builder.Property(vehicleCategory => vehicleCategory.Description)
                .HasConversion(description => description.ToString(), description => description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar(500)");
        }
    }
}
