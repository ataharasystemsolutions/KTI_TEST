using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class UnitCases
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int unitcasesID { get; set; }
        public string description { get; set; }
        public string status { get; set; }
    }
}