using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class SalesInvoiceWTax
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int DocEntry { get; set; }
        public virtual SalesInvoice VDocEntry { get; set; }
        public string WTCode { get; set; }
        public string WTName { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal Rate { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal BaseAmnt { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal TaxableAmnt { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal WTAmount { get; set; }
        public string Category { get; set; }
        public string Account { get; set; }
    }
}