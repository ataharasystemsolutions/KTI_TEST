using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class PaymentTermLines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int ID { get; set; }
        public virtual PaymentTerms VID { get; set; }
        public int IntsNo { get; set; }
        public int InstMonth { get; set; }
        public int InstDays { get; set; }
        public decimal InstPrcnt { get; set; }
    }
}