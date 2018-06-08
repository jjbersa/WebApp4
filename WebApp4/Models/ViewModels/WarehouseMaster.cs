using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace WebApp4.Models.ViewModels
{
    public partial class WarehouseMaster
    {
        public WarehouseMaster()
        {

        }
        public int whmaId { get; set; }
        public int whmaMgaaId { get; set; }
        public int qta { get; set; }
        public string code { get; set; }
        public string component { get; set; }

        public MgAnaArt whmaMgaa { get; set; }
        public IEnumerable<WarehouseDetail> warehouseDetail { get; set; }

    }
}
