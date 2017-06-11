using Sollicitatiebeheer.Model.Vacatures;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sollicitatiebeheer.Data.EFCore {
    public class SollicitatiebeheerContext : DbContext, ISollicitatiebeheerContext {

        public DbSet<Vacature> Vacatures { get; set; }
        IQueryable<Vacature> ISollicitatiebeheerContext.Vacatures => Vacatures.AsQueryable();

        public SollicitatiebeheerContext(DbContextOptions<SollicitatiebeheerContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }

        int ISollicitatiebeheerContext.SaveChanges() {
            return SaveChanges();
        }
    }
}