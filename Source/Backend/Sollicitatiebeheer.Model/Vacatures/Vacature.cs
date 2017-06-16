using System;
using Sollicitatiebeheer.Model.Afdelingen;
using Sollicitatiebeheer.Model.Shared;

namespace Sollicitatiebeheer.Model.Vacatures {
    public class Vacature : ArchiveerbareEntity<Guid> {
        public string Omschrijving { get; set; }
        public string Vacaturenummer { get; set; }
        public int AfdelingId { get; set; }
        public Afdeling Afdeling { get; set; }
        public string Functie { get; set; }
    }
}