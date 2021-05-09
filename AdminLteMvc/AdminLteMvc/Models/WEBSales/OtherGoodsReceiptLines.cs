using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class OtherGoodsReceiptLines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int DocEntry { get; set; }
        public int LineNum { get; set; }
        public virtual OtherGoodsReceipt VDocEntry { get; set; }
        [Required(ErrorMessage = "Item Code can't be empty.")]
        public string ItemCode { get; set; }
        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "Item Description can't be empty.")]
        public string Dscription { get; set; }
        [Required(ErrorMessage = "UOM can't be empty.")]
        public string UOM { get; set; }
        [Required(ErrorMessage = "Quantity can't be empty.")]
        public decimal Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        [Required(ErrorMessage = "Price can't be empty.")]
        public decimal Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        [Required(ErrorMessage = "LineTotal can't be empty.")]
        public decimal LineTotal { get; set; }
        [Display(Name = "Warehouse")]
        public string WhsCode { get; set; }
        public string Project { get; set; }
        public string OcrCode { get; set; }
        public string Account { get; set; }
        public bool ManSerNum { get; set; }
    }
}