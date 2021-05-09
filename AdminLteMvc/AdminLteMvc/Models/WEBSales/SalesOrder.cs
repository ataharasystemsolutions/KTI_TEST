using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class SalesOrder
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
        [Display(Name = "Delivery Date")]
        [Required(ErrorMessage = "Due Date can't be empty.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DocDueDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        public string CreatedTime { get; set; }

        [Display(Name = "DR #")]
        public string NumAtCard { get; set; }
        public string Remarks { get; set; }
        [Display(Name = "Total Amount")]
        [Required(ErrorMessage = "Document total must be greater than zero.")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal DocTotal { get; set; }
        [Display(Name = "Total Before Discount")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal SubTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        public decimal? Discount { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ApplyFormatInEditMode = true)]
        [Display(Name = "Downpayment")]
        public decimal DpmntAmount { get; set; }
        [Display(Name = "Branch")]
        public string Project { get; set; }
        [Display(Name = "Payment Terms")]
        public string GroupNum { get; set; }
        [Display(Name = "Prepared by")]
        public string OwnerCode { get; set; }
        [Display(Name = "Sales Agent")]
        public string SlpCode { get; set; }
        public string Address { get; set; }
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
        [Display(Name = "Price List")]
        public int PriceList { get; set; }
        public int? Installment { get; set; }
        public bool U_SAPStatus { get; set; }
        public int U_SAPDocEntry { get; set; }
        public string U_ErrorMessage { get; set; }
        public virtual List<SalesOrderLines> Lines { get; set; }
        public virtual List<SalesOrderSN> SN { get; set; }

    }
}