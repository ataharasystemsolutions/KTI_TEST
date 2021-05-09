using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class FinalBillingItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemID { get; set; }
        public int billID { get; set; }
        public string mark { get; set; }
        public string qty { get; set; }
        public string unit { get; set; }
        public string description { get; set; }
        public string value { get; set; }
        public string weight { get; set; }
        public string measurement { get; set; }

        public int lastUserId { get; set; }
        public int lastchange { get; set; }
        public string status { get; set; }

    }
}