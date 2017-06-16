using System;

namespace Sollicitatiebeheer.Model.Shared {
    public class ArchiveerbareEntity<TKey> : Entity<TKey>, IArchiveerbareEntity<TKey> {
        public bool IsGearchiveerd { get; set; }
        public DateTime TijdstipAangemaaktUtc { get; set; }
        public DateTime TijdstipLaatstGewijzigdUtc { get; set; }
    }
}
