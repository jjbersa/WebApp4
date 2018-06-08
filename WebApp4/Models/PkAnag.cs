using System;
using System.Collections.Generic;

namespace WebApp4.Models
{
    public partial class PkAnag
    {
        public PkAnag()
        {
            MgMovimenti = new HashSet<MgMovimenti>();
        }

        public int PkanId { get; set; }
        public int PkanNum { get; set; }
        public DateTime PkanData { get; set; }
        public string PkanDesc { get; set; }
        public string PkanNote { get; set; }
        public bool PkanScaric { get; set; }
        public int? PkanYear { get; set; }

        public ICollection<MgMovimenti> MgMovimenti { get; set; }

        public ICollection<PkArticoli> PkArticoli { get; set; }

    }
}
