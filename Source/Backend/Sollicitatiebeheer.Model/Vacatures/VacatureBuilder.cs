using System;
using Sollicitatiebeheer.Model.Afdelingen;

namespace Sollicitatiebeheer.Model.Vacatures {
    public class VacatureBuilder {
        private Guid _id = Guid.Empty;
        private bool _isGearchiveerd;
        private string _vacaturenummer;
        private string _omschrijving;
        private Afdeling _afdeling;
        private int _afdelingId;
        private string _functie;

        public Vacature Build() {
            var vacature = new Vacature {
                Id = _id,
                IsGearchiveerd = _isGearchiveerd,
                Vacaturenummer = _vacaturenummer,
                Omschrijving = _omschrijving,
                Afdeling = _afdeling,
                AfdelingId = _afdeling?.Id ?? _afdelingId,
                Functie = _functie
            };
            return vacature;
        }

        public VacatureBuilder MetId(Guid id) {
            _id = id;
            return this;
        }

        public VacatureBuilder MetVacaturenummer(string vacaturenummer) {
            _vacaturenummer = vacaturenummer;
            return this;
        }

        public VacatureBuilder MetOmschrijving(string omschrijving) {
            _omschrijving = omschrijving;
            return this;
        }

        public VacatureBuilder MetAfdeling(Afdeling afdeling) {
            _afdeling = afdeling;
            return MetAfdelingId(afdeling.Id);
        }

        public VacatureBuilder MetAfdelingId(int afdelingId) {
            _afdelingId = afdelingId;
            return this;
        }

        public VacatureBuilder MetFunctie(string functie) {
            _functie = functie;
            return this;
        }

        public VacatureBuilder AlsGearchiveerd() {
            _isGearchiveerd = true;
            return this;
        }
    }
}