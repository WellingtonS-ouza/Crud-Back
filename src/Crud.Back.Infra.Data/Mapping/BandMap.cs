using Crud.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Crud.Back.Infra.Data.Mapping
{
    public class BandMap : IEntityTypeConfiguration<Band>
    {
        public void Configure(EntityTypeBuilder<Band> builder)
        {
            builder.ToTable("Band");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.FormationDate)
                .IsRequired();


            builder.HasOne(b => b.Style)
                .WithMany(s => s.Bands)
                .HasForeignKey(b => b.IdStyle);

            builder.HasMany(b => b.BandMembers)
            .WithOne(bm => bm.Band)
            .HasForeignKey(bm => bm.Band);
        }
    }
}
