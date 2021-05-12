using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class ATW
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int atwID { get; set; }
        public string atwYear { get; set; }
        public string atwBkID { get; set; }
        public string atwBkNo { get; set; }
        public string bkNo { get; set; }
        public string iDate { get; set; }
        public string eDate { get; set; }
        public string aTrucker { get; set; }
        public string aDriver { get; set; }
        public string plateNo { get; set; }
        public string cShipper { get; set; }
        public string conPerson { get; set; }
        public string remarks { get; set; }
        public string issuedBy { get; set; }
        public string atwStatus { get; set; }
        public string cvno { get; set; }
        public string trns { get; set; }
        public string transactionno1 { get; set; }
        public string transactionno2 { get; set; }
        public string convanno1 { get; set; }
        public string convanno2 { get; set; }
        public string shipperno1 { get; set; }
        public string shipperno2 { get; set; }
        public string userId { get; set; }
        public DateTime? dateChange { get; set; }
    }
}