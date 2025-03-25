using Crud.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.Back.Infra.Data.Mapping
{
    public class StyleMap : IEntityTypeConfiguration<Style>
    {
        public void Configure(EntityTypeBuilder<Style> builder)
        {
            builder.ToTable("Style");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
