using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class SalesInvoiceLines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int DocEntry { get; set; }
        public virtual SalesInvoice VDocEntry { get; set; }
        [Required(ErrorMessage = "Item Code can't be empty.")]
        public string ItemCode { get; set; }
        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "Item Description can't be empty.")]
        public string Dscription { get; set; }
        [Required(ErrorMessage = "UOM can't be empty.")]
        public string UOM { get; set; }
        [Required(ErrorMessage = "Quantity can't be empty.")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "Price can't be empty.")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "LineTotal can't be empty.")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal LineTotal { get; set; }
        [Display(Name = "Warehouse")]
        public string WhsCode { get; set; }
        public string VatGroup { get; set; }
        public string Project { get; set; }
        public string OcrCode { get; set; }
        public decimal OpenQty { get; set; }
        public int? BaseRef { get; set; }
        public string BaseType { get; set; }
        public string WTLiable { get; set; }
        public bool ManSerNum { get; set; }

        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal? Dwnpayment { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal? MA { get; set; }
        public decimal Rebate { get; set; }
        public string ItemType { get; set; }
    }
}