
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class CostCenter
    {
        [Key]
        public string PrcCode { get; set; }
        public string PrcName { get; set; }
        public string Branch { get; set; }
        public bool Active { get; set; }
    }
}