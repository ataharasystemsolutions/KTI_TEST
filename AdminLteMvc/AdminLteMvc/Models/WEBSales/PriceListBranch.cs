using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class PriceListBranch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int PriceListID { get; set; }
        public virtual PriceList VPriceListID { get; set; }
        public string PrjCode { get; set; }
        public string PrjName { get; set; }
    }
}