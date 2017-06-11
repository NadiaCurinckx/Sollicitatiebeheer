using System;
using Sollicitatiebeheer.Model.Shared;

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