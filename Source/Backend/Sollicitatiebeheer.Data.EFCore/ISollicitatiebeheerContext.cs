using System.Linq;
using Sollicitatiebeheer.Model.Vacatures;
using Sollicitatiebeheer.Model.Shared;

namespace Sollicitatiebeheer.Data.EFCore {
    public interface ISollicitatiebeheerContext {
        IQueryable<Vacature> Vacatures { get; }

        void Add<TKey>(IEntity<TKey> entity);
        void Delete<TKey>(IEntity<TKey> entity);
        int SaveChanges();
    }
}