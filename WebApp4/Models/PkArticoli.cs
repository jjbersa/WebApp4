using System;
using System.Collections.Generic;

namespace WebApp4.Models
{
    public partial class PkArticoli
    {
        public PkArticoli()
        {
            MgMovimenti = new HashSet<MgMovimenti>();
        }

        public int PkarId { get; set; }
        public int PkarPkanId { get; set; }
        public int PkarMgaaId { get; set; }
        public int? PkarQtaPick { get; set; }
        public int? PkarQtaSca { get; set; }
        public short? PkarMbmgId { get; set; }
        public short? PkarMbcsId { get; set; }
        public int? PkarMgauId { get; set; }
        public int? PkarMgrgId { get; set; }
        public int? PkarMgmvProg { get; set; }
        public string PkarCodice { get; set; }
        public string PkarNote { get; set; }
        public bool PkarTransferred { get; set; }

        public MbCausal PkarMbcs { get; set; }
        public MbMag PkarMbmg { get; set; }
        public MgAnaArt PkarMgaa { get; set; }
        public PkAnag PkarPkan { get; set; }
        public MgAnaUbicazioni PkarMgau { get; set; }
        public ICollection<MgMovimenti> MgMovimenti { get; set; }
    }
}
