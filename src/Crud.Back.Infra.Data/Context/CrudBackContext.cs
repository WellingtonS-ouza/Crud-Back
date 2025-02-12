using Crud.Back.Domain.Entities;
using Crud.Back.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Crud.Back.Infra.Data.Context
{
    public class CrudBackContext : DbContext, IDisposable
    {
        public DbSet<Band> Band { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Instrument> Instrument { get; set; }
        public DbSet<Style> Style { get; set; }
        public DbSet<BandMember> BandMember { get; set; }

        public CrudBackContext(DbContextOptions<CrudBackContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Band>(new BandMap().Configure);
            modelBuilder.Entity<BandMember>(new BandMemberMap().Configure);
            modelBuilder.Entity<Instrument>(new InstrumentMap().Configure);
            modelBuilder.Entity<Member>(new MemberMap().Configure);
            modelBuilder.Entity<Style>(new StyleMap().Configure);

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
