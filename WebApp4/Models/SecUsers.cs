using System;
using System.Collections.Generic;

namespace WebApp4.Models
{
    public partial class SecUsers
    {
        public SecUsers()
        {
            MgMovimenti = new HashSet<MgMovimenti>();
            MgRegistrazioniMgrgCreationUserUsr = new HashSet<MgRegistrazioni>();
            MgRegistrazioniMgrgLastEditUserUsr = new HashSet<MgRegistrazioni>();
        }

        public int UsrId { get; set; }
        public short UsrUserType { get; set; }
        public string UsrName { get; set; }
        public string UsrLogin { get; set; }
        public string UsrPasswd { get; set; }
        public string UsrDescription { get; set; }
        public string UsrEmail { get; set; }

        public ICollection<MgMovimenti> MgMovimenti { get; set; }
        public ICollection<MgRegistrazioni> MgRegistrazioniMgrgCreationUserUsr { get; set; }
        public ICollection<MgRegistrazioni> MgRegistrazioniMgrgLastEditUserUsr { get; set; }
    }
}
