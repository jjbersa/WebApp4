using System;
using System.Collections.Generic;

namespace WebApp4.Models
{
    public partial class MgRegistrazioni
    {
        public MgRegistrazioni()
        {
            MgMovimenti = new HashSet<MgMovimenti>();
        }

        public int MgrgId { get; set; }
        public short MgrgMbmgId { get; set; }
        public short MgrgMbcsId { get; set; }
        public DateTime MgrgData { get; set; }
        public int MgrgNum { get; set; }
        public string MgrgDocRif { get; set; }
        public DateTime? MgrgDataRif { get; set; }
        public DateTime MgrgCreationDate { get; set; }
        public int? MgrgCreationUserUsrId { get; set; }
        public DateTime MgrgLastEditDate { get; set; }
        public int? MgrgLastEditUserUsrId { get; set; }

        public SecUsers MgrgCreationUserUsr { get; set; }
        public SecUsers MgrgLastEditUserUsr { get; set; }
        public MbCausal MgrgMbcs { get; set; }
        public MbMag MgrgMbmg { get; set; }
        public ICollection<MgMovimenti> MgMovimenti { get; set; }
    }
}
