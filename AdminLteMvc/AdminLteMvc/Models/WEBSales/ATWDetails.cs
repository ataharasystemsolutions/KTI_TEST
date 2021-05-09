using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class ATWDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dtlID { get; set; }
        public int atwBkID { get; set; }
        public string atwbkNo { get; set; }
        public string atwDtlStatus { get; set; }
        public string trnNo { get; set; }
        public string noUnits { get; set; }
        public string cSize { get; set; }
        public string cStatus { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
    }
}