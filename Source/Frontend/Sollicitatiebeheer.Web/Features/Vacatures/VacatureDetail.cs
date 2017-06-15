using System.Collections.Generic;
using Sollicitatiebeheer.Model.Afdelingen;
using Sollicitatiebeheer.Model.Vacatures;

namespace Sollicitatiebeheer.Web.Features.Vacatures {
    public class VacatureDetail {
        public Vacature Vacature { get; set; }
        public List<Afdeling> Afdelingen { get; set; }
        public string GeselecteerdeAfdeling { get; set; }
    }
}
