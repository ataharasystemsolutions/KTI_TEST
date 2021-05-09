using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class Comaker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComakerID { get; set; }
        public string CardCode { get; set; }
        public virtual BusinessPartner VCardCode { get; set; }
        [Display(Name = "CoMaker Name")]
        public string CoMakerName { get; set; }
        [Display(Name = "CoMaker Address")]
        public string CoMakerAddress { get; set; }
        [Display(Name = "Contact No")]
        public string Contact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}