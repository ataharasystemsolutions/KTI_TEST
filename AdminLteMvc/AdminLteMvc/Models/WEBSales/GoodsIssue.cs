using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class GoodsIssue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocEntry { get; set; }
        [Display(Name = "Document Number")]
        public int DocNum { get; set; }

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
        public bool U_SAPStatus { get; set; }
        public int U_SAPDocEntry { get; set; }
        public string U_ErrorMessage { get; set; }
        public virtual List<GoodsIssueLines> Lines { get; set; }
        public virtual List<GoodsIssueSN> SN { get; set; }
    }
}