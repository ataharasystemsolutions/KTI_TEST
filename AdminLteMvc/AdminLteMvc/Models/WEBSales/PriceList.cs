using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class PriceList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PriceListID { get; set; }
        [Display(Name = "Price List Name")]
        [Required]
        public string PriceListName { get; set; }
        //public string Branch { get; set; }
        [Display(Name = "Prepared By")]
        public string Preparedby { get; set; }
        [Display(Name = "Item Group")]
        public string ItemGroup { get; set; }
        [Display(Name = "Valid From")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Validfrom { get; set; }
        [Display(Name = "Valid To")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Validto { get; set; }
        [Display(Name = "Approved By")]
        public string Approvedby { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Mark-up Rate")]
        public decimal LCP { get; set; }
        [Display(Name = "Annual Rate")]
        public decimal AnnualRate { get; set; }
         [Display(Name = "Type")]
        public string PriceListType { get; set; }
        public virtual List<WEBSales.PriceListLines> PriceListLines { get; set; }
        public virtual List<WEBSales.PriceListBranch> Branch { get; set; }
    }
}