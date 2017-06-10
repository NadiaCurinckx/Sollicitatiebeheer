using System;
using Sollicitatiebeheer.Model.Common;

namespace Sollicitatiebeheer.Model.Vacatures {
    public class Vacature : Entity<Guid> {
        public string Naam { get; protected set; }

        protected Vacature() { }
        internal Vacature(Guid id, string naam) {
            Id = id;
            Naam = naam;
        }
    }
}
