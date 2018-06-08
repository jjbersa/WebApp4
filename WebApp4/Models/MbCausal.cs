using System;
using System.Collections.Generic;

namespace WebApp4.Models
{
    public partial class MbCausal
    {
        public MbCausal()
        {
            MgRegistrazioni = new HashSet<MgRegistrazioni>();
            PkArticoli = new HashSet<PkArticoli>();
        }

        public short MbcsId { get; set; }
        public short MbcsMbmgId { get; set; }
        public string MbcsCaus { get; set; }
        public string MbcsDescr { get; set; }
        public int? MbcsMgauId { get; set; }

        public MbMag MbcsMbmg { get; set; }
        public MgAnaUbicazioni MbcsMgau { get; set; }
        public ICollection<MgRegistrazioni> MgRegistrazioni { get; set; }
        public ICollection<PkArticoli> PkArticoli { get; set; }
    }
}
