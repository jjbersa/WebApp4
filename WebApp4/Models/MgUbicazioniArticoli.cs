using System;
using System.Collections.Generic;

namespace WebApp4.Models
{
    public partial class MgUbicazioniArticoli
    {
        public int MguaId { get; set; }
        public int MguaMgaaId { get; set; }
        public short MguaMbmgId { get; set; }
        public int MguaMgauId { get; set; }

        public MbMag MguaMbmg { get; set; }
        public MgAnaArt MguaMgaa { get; set; }
        public MgAnaUbicazioni MguaMgau { get; set; }
    }
}
