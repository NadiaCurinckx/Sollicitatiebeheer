using System;
using Sollicitatiebeheer.Model.Shared;

namespace Sollicitatiebeheer.Model.Vacatures
{
    public class Vacature : Entity<Guid>
    {
        //Properties
        public string Omschrijving { get; protected set; }

        public string Vacaturenummer { get; set; }

        public string Afdeling { get; set; }

        public string Functie { get; set; }

        //Constructors
        protected Vacature() { }
        internal Vacature(Guid id, string vacaturenummer, string omschrijving, string afdeling, string functie)
        {
            Id = id;
            Vacaturenummer = vacaturenummer;
            Omschrijving = omschrijving;
            Afdeling = afdeling;
            Functie = functie;
        }
    }
}