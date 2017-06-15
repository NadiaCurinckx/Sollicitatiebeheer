using System.Linq;
using Sollicitatiebeheer.Model.Vacatures;
using Sollicitatiebeheer.Model.Shared;
using System;
using System.Collections.Generic;
using Sollicitatiebeheer.Model.Afdelingen;

namespace Sollicitatiebeheer.Data.EFCore {
    public interface ISollicitatiebeheerContext : IDisposable {
        IQueryable<Afdeling> Afdelingen { get; }
        IQueryable<Vacature> Vacatures { get; }        

        void Add<TKey>(IEntity<TKey> entity);
        void AddRange<TKey>(IEnumerable<IEntity<TKey>> entities);
        void Update<TKey>(IEntity<TKey> entity);
        void Delete<TKey>(IEntity<TKey> entity);        
        int SaveChanges();
    }
}