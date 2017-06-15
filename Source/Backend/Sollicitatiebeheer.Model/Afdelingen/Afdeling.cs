using Sollicitatiebeheer.Model.Shared;

namespace Sollicitatiebeheer.Model.Afdelingen {
    public class Afdeling : ArchiveerbareEntity<int> {
        public string Naam { get; set; }
    }
}