using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp4.Models
{
    public partial class MgAnaArt
    {
        public MgAnaArt()
        {
            MgMovimenti = new HashSet<MgMovimenti>();
            MgUbicazioniArticoli = new HashSet<MgUbicazioniArticoli>();
            PkArticoli = new HashSet<PkArticoli>();
        }

        public int MgaaId { get; set; }
        public string MgaaMbdcClasse { get; set; }
        public string MgaaMatricola { get; set; }
        public string MgaaDescr { get; set; }
        public string MgaaNote { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? MgaaDataIns { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? MgaaDataUltMod { get; set; }

        public ICollection<MgMovimenti> MgMovimenti { get; set; }
        public ICollection<MgUbicazioniArticoli> MgUbicazioniArticoli { get; set; }
        public ICollection<PkArticoli> PkArticoli { get; set; }
    }
}
