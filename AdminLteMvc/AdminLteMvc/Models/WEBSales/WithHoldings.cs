using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class WithHoldings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string WTCode { get; set; }
        public string WTName { get; set; }
        public bool InActive { get; set; }
        public string Category { get; set; }
        public decimal Rate { get; set; }
        public decimal BaseAmnt { get; set; }
        public string OffclCode { get; set; }
        public string Account { get; set; }
    }
}