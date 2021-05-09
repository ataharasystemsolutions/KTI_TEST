using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class InvTransfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocEntry { get; set; }
        [Display(Name = "Document Number")]
        public int DocNum { get; set; }
        [Display(Name = "Business Partner")]
        public string CardCode { get; set; }
        [Display(Name = "Name")]
        public string CardName { get; set; }

        [Display(Name = "Posting Date")]
        [Required(ErrorMessage = "Posting Date can't be empty.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DocDate { get; set; }
        [Display(Name = "Document Date")]
        [Required(ErrorMessage = "Document Date can't be empty.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TaxDate { get; set; }
        public string Remarks { get; set; }
        [Display(Name = "From Warehouse")]
        [Required(ErrorMessage = "From Warehouse can't be empty.")]
        public string FromWhsCode { get; set; }
        [Display(Name = "To Warehouse")]
        [Required(ErrorMessage = "To Warehouse can't be empty.")]
        public string ToWhsCode { get; set; }
        [Display(Name = "Sales Employee")]
        public string SlpCode { get; set; }
        public bool U_SAPStatus { get; set; }
        public int U_SAPDocEntry { get; set; }
        public string U_ErrorMessage { get; set; }
        public virtual List<InvTransferLines> Lines { get; set; }
        public virtual List<InvTransferSN> SN { get; set; }
      
    }
}