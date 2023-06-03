﻿using IndexMarket.Domain.Constant;
using IndexMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndexMarket.Infrastructure.EntityTypeConfiguration;
public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(TableNames.Product);

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.PhotoLink)
            .HasMaxLength(255)
            .IsRequired(false);

        builder
            .Property(p => p.Price)
            .IsRequired(true);

        builder
            .Property(p => p.Amount)
            .IsRequired(true);

        builder
            .Property(p => p.Frame)
            .HasMaxLength(100)
            .IsRequired(true);

        builder
            .Property(p => p.Height)
            .IsRequired(true);

        builder
            .Property(p => p.Weight)
            .IsRequired(false);

        builder
            .Property(p => p.CreatedAt)
            .IsRequired(true);

        builder
            .Property(p => p.Type)
            .IsRequired(true);

        builder
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.Category_Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}