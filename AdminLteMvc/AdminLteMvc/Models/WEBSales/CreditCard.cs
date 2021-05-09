using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class CreditCard
    {
        [Key]
        public string CardName { get; set; }
        public string AcctCode { get; set; }
    }
}