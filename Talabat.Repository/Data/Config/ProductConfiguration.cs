using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data.Config
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .IsRequired();

            builder.Property(e => e.PictureUrl)
                .IsRequired();

            builder.Property(e => e.Price)
                .HasColumnType("float");

            builder.HasOne(e => e.Brand)
                .WithMany()
                .HasForeignKey(b => b.BrandId);

            builder.HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId);


        }
    }
}
