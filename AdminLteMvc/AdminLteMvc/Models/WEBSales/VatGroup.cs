using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class VatGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string VatCode { get; set; }
        public string VatName { get; set; }
        public bool Inactive { get; set; }
        public string Category { get; set; }
        public decimal Rate { get; set; }
    }
}