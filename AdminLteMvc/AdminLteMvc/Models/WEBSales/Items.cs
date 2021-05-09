using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class Items
    {
        [Key]
        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Foreign Name")]
        public string FrgnName { get; set; }
        [Display(Name = "Purchase Item")]
        public bool PrchseItem { get; set; }
        [Display(Name = "Sales Item")]
        public bool SellItem { get; set; }
        [Display(Name = "Inventory Item")]
        public bool InvntItem { get; set; }
        public string Barcode { get; set; }
        public decimal? LastPurPrice { get; set; }
        public bool Active { get; set; }

        [Display(Name = "Purchasing UOM Name")]
        public string BuyUnitMsr { get; set; }

        [Display(Name = "Tax Group")]
        public string VatGroupPu { get; set; }

        [Display(Name = "Sales UOM Name")]
        public string SalUnitMsr { get; set; }

        [Display(Name = "Tax Group")]
        public string VatGroupSa { get; set; }
        [Display(Name = "Manage Item by Serial Number")]
        public bool ManSerNum { get; set; }

        [Display(Name = "Inventory UOM Name")]
        public string InvUnitMsr { get; set; }
        public virtual List<Inventory> Inventory { get; set; }

    }
}