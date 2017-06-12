using Sollicitatiebeheer.Model.Vacatures;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sollicitatiebeheer.Data.EFCore.Infrastructure.Extensions;
using Sollicitatiebeheer.Model.Shared;
using System;

namespace Sollicitatiebeheer.Data.EFCore {
    public class SollicitatiebeheerContext : DbContext, ISollicitatiebeheerContext {

        public DbSet<Vacature> Vacatures { get; set; }
        IQueryable<Vacature> ISollicitatiebeheerContext.Vacatures => Vacatures.AsQueryable();

        public SollicitatiebeheerContext(DbContextOptions<SollicitatiebeheerContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vacature>(e => {
                e.Property(p => p.Id).HasDefaultValueSequentialIdSql();
            });
        }

        int ISollicitatiebeheerContext.SaveChanges() {
            return SaveChanges();
        }
        void ISollicitatiebeheerContext.Add<TKey>(IEntity<TKey> entity)
        {
            Add(entity);
        }
    }
}