using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminLteMvc.Models.WEBSales;

namespace AdminLteMvc.Models.Class
{
    public class onboardVessel
    {
        public AdminLteMvc.Models.WEBSales.onboardVessel datParent { get; set; }
        public List<onboardVesselLoadItem> data { get; set; }
    }
}