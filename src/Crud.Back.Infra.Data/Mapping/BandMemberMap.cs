using Crud.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.Back.Infra.Data.Mapping
{
    public class BandMemberMap : IEntityTypeConfiguration<BandMember>
    {
        public void Configure(EntityTypeBuilder<BandMember> builder)
        {
            builder.ToTable("BandMember");

            builder.HasKey(bm => bm.Id);

            builder.HasOne(bm => bm.Band)
                .WithMany(b => b.BandMembers)
                .HasForeignKey(bm => bm.IdBand);

            builder.HasOne(bm => bm.Member)
                .WithMany(m => m.BandMembers)
                .HasForeignKey(bm => bm.IdMember);
        }
    }
}
