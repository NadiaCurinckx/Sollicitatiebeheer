using System;

namespace Sollicitatiebeheer.Model.Vacatures
{
    public class VacatureBuilder
    {

        //Properties
        private Guid _id;
        private string _vacaturenummer;
        private string _omschrijving;
        private string _afdeling;
        private string _functie;

        //Constructor
        public VacatureBuilder() : base() { }

        //Methodes
        public Vacature Build()
        {
            return new Vacature(_id, _vacaturenummer, _omschrijving, _afdeling, _functie);
        }

        public VacatureBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public VacatureBuilder WithVacaturenummer(string vacaturenummer)
        {
            _vacaturenummer = vacaturenummer;
            return this;
        }

        public VacatureBuilder WithOmschrijving(string omschrijving)
        {
            _omschrijving = omschrijving;
            return this;
        }

        public VacatureBuilder WithAfdeling(string afdeling)
        {
            _afdeling = afdeling;
            return this;
        }

        public VacatureBuilder WithFunctie(string functie)
        {
            _functie = functie;
            return this;
        }

    }
}