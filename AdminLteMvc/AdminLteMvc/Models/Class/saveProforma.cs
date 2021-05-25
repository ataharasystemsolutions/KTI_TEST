using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminLteMvc.Models.WEBSales;

namespace AdminLteMvc.Models.Class
{
    public class saveProforma
    {
        public ProformaBills datParent { get; set; }
        public List<ProformaBillsItems> data { get; set; }
    }
}