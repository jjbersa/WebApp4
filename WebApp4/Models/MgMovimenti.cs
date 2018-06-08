using System;
using System.Collections.Generic;

namespace WebApp4.Models
{
    public partial class MgMovimenti
    {
        public int MgmvId { get; set; }
        public int MgmvMgrgId { get; set; }
        public int MgmvProg { get; set; }
        public int MgmvMgaaId { get; set; }
        public decimal? MgmvQuantita { get; set; }
        public int? MgmvIdRegDest { get; set; }
        public int? MgmvIdRegProv { get; set; }
        public string MgmvCodUbi { get; set; }
        public int? MgmvMgauId { get; set; }
        public int? MgmvPkanId { get; set; }
        public DateTime? MgmvDataIns { get; set; }
        public int? MgmvUsrId { get; set; }
        public int? MgmvPkarId { get; set; }
        public string MgmvNote { get; set; }

        public MgAnaArt MgmvMgaa { get; set; }
        public MgAnaUbicazioni MgmvMgau { get; set; }
        public MgRegistrazioni MgmvMgrg { get; set; }
        public PkAnag MgmvPkan { get; set; }
        public PkArticoli MgmvPkar { get; set; }
        public SecUsers MgmvUsr { get; set; }
    }
}
