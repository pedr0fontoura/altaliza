﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Altaliza.Domain.Entities;

namespace Altaliza.Infra.Mapping
{
    public class CharacterMap : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("characters");

            builder.HasKey(character => character.Id);

            builder.Property(character => character.Name)
                .HasConversion(name => name.ToString(), name => name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            builder.Property(character => character.Wallet)
                .IsRequired()
                .HasColumnName("Wallet")
                .HasColumnType("float");
        }
    }
}
