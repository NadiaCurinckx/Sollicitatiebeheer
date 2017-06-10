using System;
using Sollicitatiebeheer.Model.Common;

namespace Sollicitatiebeheer.Model.Vacatures {
    public class VacatureBuilder {
        private Guid _id;
        private string _naam;

        public VacatureBuilder() : base() { }

        public Vacature Build() {
            return new Vacature(_id, _naam);
        }

        public VacatureBuilder WithId(Guid id) {
            _id = id;
            return this;
        }

        public VacatureBuilder WithNaam(string naam) {
            _naam = naam;
            return this;
        }
    }
}
