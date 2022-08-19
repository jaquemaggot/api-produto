using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {

            builder.ToTable("Product");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Title);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description);
            builder.Property(p => p.Height);
            builder.Property(p => p.Width);
            builder.Property(p => p.Length);
            builder.Property(p => p.Weight).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Gtin).IsUnicode();
            builder.Property(p => p.Value);
            builder.Property(p => p.AcquisitionDate);
            builder.Property(p => p.ImageBase64);
        }
    }
}
