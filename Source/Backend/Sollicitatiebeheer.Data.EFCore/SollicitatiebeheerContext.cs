using Sollicitatiebeheer.Model.Vacatures;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sollicitatiebeheer.Data.EFCore.Infrastructure.Extensions;
using Sollicitatiebeheer.Model.Shared;
using System;
using System.Collections.Generic;
using Sollicitatiebeheer.Model.Afdelingen;

namespace Sollicitatiebeheer.Data.EFCore {
    public class SollicitatiebeheerContext : DbContext, ISollicitatiebeheerContext {

        public DbSet<Afdeling> Afdelingen { get; set; }
        IQueryable<Afdeling> ISollicitatiebeheerContext.Afdelingen => Afdelingen.AsQueryable();
        public DbSet<Vacature> Vacatures { get; set; }
        IQueryable<Vacature> ISollicitatiebeheerContext.Vacatures => Vacatures.Where(v => !v.IsGearchiveerd).AsQueryable();

        public SollicitatiebeheerContext(DbContextOptions<SollicitatiebeheerContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Afdeling>(e =>
            {
                e.Property(p => p.Id).UseSqlServerIdentityColumn();
            });
            modelBuilder.Entity<Vacature>(e => 
            {
                e.Property(p => p.Id).HasDefaultValueSequentialIdSql();
            });
        }

        int ISollicitatiebeheerContext.SaveChanges()
        {
            return SaveChanges();
        }
        void ISollicitatiebeheerContext.Add<TKey>(IEntity<TKey> entity)
        {
            Add(entity);
        }
        void ISollicitatiebeheerContext.AddRange<TKey>(IEnumerable<IEntity<TKey>> entities)
        {
            AddRange(entities);
        }
        void ISollicitatiebeheerContext.Update<TKey>(IEntity<TKey> entity)
        {
            Entry(entity).State = EntityState.Modified;
            Update(entity);
        }
        void ISollicitatiebeheerContext.Delete<TKey>(IEntity<TKey> entity)
        {
            if(entity is IArchiveerbaar)
            {
                ((IArchiveerbaar)entity).IsGearchiveerd = true;
            }
            else
            {
                Remove(entity);
            }            
        }        
    }
}