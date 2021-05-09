using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminLteMvc.Models.Class;
using AdminLteMvc.Models.WEBSales;

namespace AdminLteMvc.Models.Class
{
    public class saveBilloflading
    {
        public FinalBilling datParent { get; set; }
        public List<FinalBillingItem> data { get; set; }
    }
}