using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace WebApp4.Models.ViewModels
{
    public partial class WarehouseDetail 
    {
        public WarehouseDetail()
        {
        }
        public int whdtId { get; set; }
        public int whdtMgaaId { get; set; }
        public int whdtWhmaId { get; set; }
        public int qta { get; set; }
        public string code { get; set; }
        public string component { get; set; }
        public string pallet { get; set; }
        public string warehouse { get; set; }
        public string ubication { get; set; }

        public MgAnaArt whdtMgaa { get; set; }
        public WarehouseMaster whdtWhma { get; set; }

       
    }
}
