using Microsoft.EntityFrameworkCore;
using MoneyBocket.Domain.Models;

namespace MoneyBocket.Persistence.Categories
{
    public class CategoryConfiguration
        : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property<string>(x => x.Name)
                .IsRequired(required: true);

            builder.Property(p => p.Name)
                .HasMaxLength(150);

        }
    }
}
