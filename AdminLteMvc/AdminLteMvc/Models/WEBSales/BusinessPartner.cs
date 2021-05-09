using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class BusinessPartner
    {
        [Key]
        [Required(ErrorMessage = "Cardcode is required")]
        [Display(Name = "Code")]
        public string CardCode { get; set; }
        [Display(Name = "Name")]
        public string CardName { get; set; }
        [Display(Name = "Spouse Name")]
        public string ForeignName { get; set; }
        [Display(Name = "BP Type")]
        public string BPType { get; set; }
        public string Type { get; set; }
  
        public string Phone { get; set; }
        [Display(Name = "Phone 2")]
        public string Phone2 { get; set; }
        public string Address { get; set; }
        [Display(Name = "TIN Number")]
        public string LicTradNum { get; set; }
        [Display(Name = "Alias Name")]
        public string AliasName { get; set; }
        [Display(Name = "Branch")]
        public string ProjectCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        [Display(Name = "Barangay")]
        public string Baranggay { get; set; }
        public string Street { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name = "Area Code")]
        public string AreaCode { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Civil Status")]
        public string CivilStatus { get; set; }
        public string Occupation { get; set; }
        public string Position { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        public string Website { get; set; }
        public string SSSNo { get; set; }
        public string Cedula { get; set; }
        [Display(Name = "Date Issued")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateIssued { get; set; }
        [Display(Name = "Place Issued")]
        public string PlaceIssued { get; set; }
        [Display(Name = "Tax Status")]
        public string VatStatus { get; set; }
        [Display(Name = "Tax Group")]
        public string VatGroup { get; set; }
        [Display(Name = "Subject to Withholding Tax")]
        public bool WTLiable { get; set; }
        public bool Active { get; set; }
        public int Series { get; set; }
        [Display(Name = "Photo")]
        public string ImagePath { get; set; }
        public byte[] Photo { get; set; }
        [Display(Name = "Customer Name")]
        public string CardLName { get; set; }
        public string CardFName { get; set; }
        public string CardMName { get; set; }
        public string ForeignFName { get; set; }
        public string ForeignLName { get; set; }
        public string ForeignMName { get; set; }
        public virtual List<Comaker> CoMaker { get; set; }
        public virtual List<BPWithHolding> WithHolding { get; set; }
    }
}