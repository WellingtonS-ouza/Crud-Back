using Crud.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.Back.Infra.Data.Mapping
{
    public class InstrumentMap : IEntityTypeConfiguration<Instrument>
    {
        public void Configure(EntityTypeBuilder<Instrument> builder)
        {
            builder.ToTable("Instrument");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(i => i.Members)
              .WithOne(m => m.Instrument)
              .HasForeignKey(m => m.IdInstrument)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
