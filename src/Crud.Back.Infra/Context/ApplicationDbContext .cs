using System.Collections.Generic;
using System.Reflection.Emit;
using Crud.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud.Back.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Band> Band { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Instrument> Instrument { get; set; }
        public DbSet<Style> Style { get; set; }
        public DbSet<BandMember> BandMember { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
