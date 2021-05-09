using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class Incoming
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocEntry { get; set; }
        [Display(Name = "Document Number")]
        public int DocNum { get; set; }
        [Display(Name = "BP Code")]
        [Required(ErrorMessage = "BP Code can't be empty.")]
        public string CardCode { get; set; }
        [Display(Name = "BP Name")]
        [Required(ErrorMessage = "BP Name can't be empty.")]
        public string CardName { get; set; }
        [Display(Name = "Posting Date")]
        [Required(ErrorMessage = "Posting Date can't be empty.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DocDate { get; set; }
        [Display(Name = "Document Date")]
        [Required(ErrorMessage = "Document Date can't be empty.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TaxDate { get; set; }
        [Display(Name = "Due Date")]
        [Required(ErrorMessage = "Due Date can't be empty.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DocDueDate { get; set; }
        public string Reference { get; set; }
        [Display(Name = "Branch")]
        public string PrjCode { get; set; }
        public string Remarks { get; set; }
        public string CashAcct { get; set; }
        public string TrsfrAcct { get; set; }
        [Display(Name = "Transfer Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? TrsfrDate { get; set; }
        public string TrsfrRef { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal? CashSum { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal? CreditSum { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal? CheckSum { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal? TrsfrSum { get; set; }
        [Display(Name = "Total Amount Due")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal DocTotal { get; set; }
        [Display(Name = "Official Receipt")]
        public string OfficialReceipt { get; set; }
        [Display(Name = "Collection Receipt")]
        public string CollectionReceipt { get; set; }
        [Display(Name = "Sales Invoice Receipt")]
        public string SIReceipt { get; set; }
        [Display(Name = "Temporary/Probationary Receipt")]
        public string TPReceipt { get; set; }
        public bool U_SAPStatus { get; set; }
        public int U_SAPDocEntry { get; set; }
        public string U_ErrorMessage { get; set; }
        public virtual List<IncomingLines> PaymentLines { get; set; }
        public virtual List<IncomingCards> PaymentCards { get; set; }
        public virtual List<IncomingChecks> PaymentChecks { get; set; }
    }
}