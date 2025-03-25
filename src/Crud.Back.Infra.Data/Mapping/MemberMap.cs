using Crud.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.Back.Infra.Data.Mapping
{
    public class MemberMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Age)
                .IsRequired();

            builder.Property(m => m.Gender)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(m => m.Instrument)
                .WithMany(i => i.Members)
                .HasForeignKey(m => m.IdInstrument);
        }
    }
}
