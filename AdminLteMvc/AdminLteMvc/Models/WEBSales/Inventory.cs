using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class Inventory
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryID { get; set; }
        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }
        public virtual Items VItemCode { get; set; }
        [Display(Name = "Warehouse Code")]
        public string WhsCode { get; set; }
        [Display(Name = "Warehouse Name")]
        public string WhsName { get; set; }
        [Display(Name = "In Stock")]
        public int OnHand { get; set; }
        [Display(Name = "Committed")]
        public int IsCommited { get; set; }
        [Display(Name = "Ordered")]
        public int OnOrder { get; set; }
        public bool Locked { get; set; }
        public decimal MinStock { get; set; }
        public decimal MaxStock { get; set; }
        public string Branch { get; set; }
    }
}