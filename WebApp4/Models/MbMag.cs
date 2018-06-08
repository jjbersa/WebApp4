using System;
using System.Collections.Generic;

namespace WebApp4.Models
{
    public partial class MbMag
    {
        public MbMag()
        {
            MbCausal = new HashSet<MbCausal>();
            MgAnaUbicazioni = new HashSet<MgAnaUbicazioni>();
            MgRegistrazioni = new HashSet<MgRegistrazioni>();
            MgUbicazioniArticoli = new HashSet<MgUbicazioniArticoli>();
            PkArticoli = new HashSet<PkArticoli>();
        }

        public short MbmgId { get; set; }
        public short? MbmgMag { get; set; }
        public string MbmgDescr { get; set; }
        public DateTime? MbmgDataFinVal { get; set; }
        public string MbmgCode { get; set; }

        public ICollection<MbCausal> MbCausal { get; set; }
        public ICollection<MgAnaUbicazioni> MgAnaUbicazioni { get; set; }
        public ICollection<MgRegistrazioni> MgRegistrazioni { get; set; }
        public ICollection<MgUbicazioniArticoli> MgUbicazioniArticoli { get; set; }
        public ICollection<PkArticoli> PkArticoli { get; set; }
    }
}
