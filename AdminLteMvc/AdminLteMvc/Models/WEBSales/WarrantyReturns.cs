using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class WarrantyReturns
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocEntry { get; set; }
        [Display(Name = "Document Number")]
        public int DocNum { get; set; }
        [Display(Name = "Customer Code")]
        [Required(ErrorMessage = "Customer Code can't be empty.")]
        public string CardCode { get; set; }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer Name can't be empty.")]
        public string CardName { get; set; }

        [Display(Name = "Posting Date")]
        [Required(ErrorMessage = "Posting Date can't be empty.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DocDate { get; set; }
        [Display(Name = "Document Date")]
        [Required(ErrorMessage = "Document Date can't be empty.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TaxDate { get; set; }
        [Display(Name = "Reference")]
        public string NumAtCard { get; set; }
        public string Remarks { get; set; }
        public string UserSign { get; set; }
        [Display(Name = "Total Amount")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal DocTotal { get; set; }
        public bool U_SAPStatus { get; set; }
        public int U_SAPDocEntry { get; set; }
        public string U_ErrorMessage { get; set; }
        public virtual List<WarrantyReturnLines> Lines { get; set; }
        public virtual List<WarrantyReturnSN> SN { get; set; }
    }
}