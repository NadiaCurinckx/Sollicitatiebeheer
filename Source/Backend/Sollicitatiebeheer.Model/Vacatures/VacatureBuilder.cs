using System;

namespace Sollicitatiebeheer.Model.Vacatures
{
    public class VacatureBuilder
    {

        //Properties
        private Guid _id = Guid.Empty;
        private bool _isGearchiveerd;
        private string _vacaturenummer;
        private string _omschrijving;
        private string _afdeling;
        private string _functie;

        //Constructor
        public VacatureBuilder() : base() { }

        //Methodes
        public Vacature Build()
        {
            var vacature = new Vacature(_id, _vacaturenummer, _omschrijving, _afdeling, _functie);
            vacature.IsGearchiveerd = _isGearchiveerd;
            return vacature;
        }

        public VacatureBuilder MetId(Guid id)
        {
            _id = id;
            return this;
        }

        public VacatureBuilder MetVacaturenummer(string vacaturenummer)
        {
            _vacaturenummer = vacaturenummer;
            return this;
        }

        public VacatureBuilder MetOmschrijving(string omschrijving)
        {
            _omschrijving = omschrijving;
            return this;
        }

        public VacatureBuilder MetAfdeling(string afdeling)
        {
            _afdeling = afdeling;
            return this;
        }

        public VacatureBuilder MetFunctie(string functie)
        {
            _functie = functie;
            return this;
        }

        public VacatureBuilder AlsGearchiveerd()
        {
            _isGearchiveerd = true;
            return this;
        }
    }
}