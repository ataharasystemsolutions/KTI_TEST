using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class ProformaBillsItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }
        public int proformaBillID { get; set; }

        public string marks { get; set; }
        public decimal quantity { get; set; }
        public string unit { get; set; }
        public string description { get; set; }

        public string status { get; set; }

    }
}