using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class IncomingCards
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int DocEntry { get; set; }
        public virtual Incoming VDocEntry { get; set; }
        public string CreditCardCode { get; set; }
        public string CreditAcc { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardValid { get; set; }
        public int VoucherNum { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal CreditSum { get; set; }
    }
}