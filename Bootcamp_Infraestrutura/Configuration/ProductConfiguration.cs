using Bootcamp_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bootcamp_Infraestrutura.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }
}
