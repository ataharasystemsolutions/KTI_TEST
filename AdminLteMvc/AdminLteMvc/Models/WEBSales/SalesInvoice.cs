using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class SalesInvoice
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
        public string Status { get; set; }
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

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        public string CreatedTime { get; set; }

        [Display(Name = "DR #")]
        public string NumAtCard { get; set; }
        public string Remarks { get; set; }
        [Required(ErrorMessage = "Document total must be greater than zero.")]
        [Display(Name = "Total Amount")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal DocTotal { get; set; }
        [Display(Name = "Total Before Discount")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal SubTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        [Display(Name = "WTax")]
        public decimal? WTaxTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal? PaidTodate { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        [Display(Name = "Downpayment")]
        public decimal DpmntAmount { get; set; }
        public int? ReceiptNum { get; set; }
        public decimal? Discount { get; set; }
        [Display(Name = "Branch")]
        public string Project { get; set; }
        [Display(Name = "Payment Terms")]
        public string GroupNum { get; set; }
        [Display(Name = "Prepared by")]
        public string OwnerCode { get; set; }
        [Display(Name = "Sales Agent")]
        public string SlpCode { get; set; }
        public string Address { get; set; }

        [Display(Name = "Price List")]
        public int PriceList { get; set; }
        public int? Installment { get; set; }
        [Display(Name = "Invoice Type")]
        public string ActivityType { get; set; }
        public bool U_SAPStatus { get; set; }
        public int U_SAPDocEntry { get; set; }
        public string U_ErrorMessage { get; set; }

        [Display(Name = "Promissory Note CTC No.")]
        public string PNIssuedNo { get; set; }
        [Display(Name = "Promissory Note Issued At")]
        public string PNIssuedAt { get; set; }
        [Display(Name = "Promissory Note Issued Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PNIssuedDate { get; set; }
        [Display(Name = "Chattel Mortgage Issued Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CMIssuedDate { get; set; }
        [Display(Name = "Chattel Mortgage Interest Rate")]
        public decimal? InterestRate { get; set; }
        public string Assignee { get; set; }
        [Display(Name = "Delivery Receipt #")]
        public string DRNo { get; set; }
        [Display(Name = "Sales Invoice #")]
        public string SINo { get; set; }
        [Display(Name = "Charge Invoice #")]
        public string CINo { get; set; }
        [Display(Name = "WR #")]
        public string WRNo { get; set; }
        public virtual List<SalesInvoiceLines> Lines { get; set; }
        public virtual List<SalesInvoiceSN> SN { get; set; }
        public virtual List<SalesInvoiceWTax> WTax { get; set; }
        public virtual List<SalesInvoiceInst> Inst { get; set; }
        public virtual List<SalesInvoicePL> PList { get; set; }
    }
}