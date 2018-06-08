using System;
using System.Collections.Generic;

namespace WebApp4.Models
{
    public partial class MgAnaUbicazioni
    {
        public MgAnaUbicazioni()
        {
            MbCausal = new HashSet<MbCausal>();
            MgMovimenti = new HashSet<MgMovimenti>();
            MgUbicazioniArticoli = new HashSet<MgUbicazioniArticoli>();
            PkArticoli = new HashSet<PkArticoli>();
        }

        public int MgauId { get; set; }
        public short MgauMbmgId { get; set; }
        public string MgauCodice { get; set; }
        public string MgauCodCompl { get; set; }
        public string MgauDescr { get; set; }
        public string MgauTreeCtrl { get; set; }
        public DateTime MgauDataIns { get; set; }
        
        public int? MgauLivello { get; set; }
        public decimal? MgauProfondita { get; set; }
        public decimal? MgauLarghezza { get; set; }
        public decimal? MgauAltezza { get; set; }
        public bool MgauBloccata { get; set; }
        public bool MgauPrenotata { get; set; }
        public bool? MgauUbiDef { get; set; }

        public MbMag MgauMbmg { get; set; }
        
        
        public ICollection<MbCausal> MbCausal { get; set; }
        public ICollection<MgMovimenti> MgMovimenti { get; set; }
        public ICollection<MgUbicazioniArticoli> MgUbicazioniArticoli { get; set; }
        public ICollection<PkArticoli> PkArticoli { get; set; }
    }
}
