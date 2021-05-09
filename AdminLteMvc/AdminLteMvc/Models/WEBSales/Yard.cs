using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class Yard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int yardID { get; set; }
        public string yardStatus { get; set; }
        public string yardATWBkNo { get; set; }
        public string yardTrnNo { get; set; }
        public string yardConVanNo { get; set; }
        public string yardAssignedBy { get; set; }
    }
}