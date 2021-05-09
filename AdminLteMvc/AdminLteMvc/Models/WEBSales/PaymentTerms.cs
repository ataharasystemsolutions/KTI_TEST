using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class PaymentTerms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int GroupNum { get; set; }
        public string PymntGrp { get; set; }
        public int ExtraMonth { get; set; }
        public int ExtraDays { get; set; }
        public int InstNum { get; set; }
        public virtual List<PaymentTermLines> PaymentTermLines { get; set; }
    }
}