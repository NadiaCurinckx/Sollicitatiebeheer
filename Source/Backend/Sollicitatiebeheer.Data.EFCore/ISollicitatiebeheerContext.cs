using System.Linq;
using Sollicitatiebeheer.Model.Vacatures;

namespace Sollicitatiebeheer.Data.EFCore {
    public interface ISollicitatiebeheerContext {
        IQueryable<Vacature> Vacatures { get; }

        int SaveChanges();
    }
}