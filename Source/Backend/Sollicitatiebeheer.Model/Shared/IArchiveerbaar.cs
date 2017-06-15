using System;

namespace Sollicitatiebeheer.Model.Shared {
    public interface IArchiveerbaar {
        bool IsGearchiveerd { get; set; }
        DateTime TijdstipAangemaaktUtc { get; set; }
        DateTime TijdstipLaatstGewijzigdUtc { get; set; }
    }
}
