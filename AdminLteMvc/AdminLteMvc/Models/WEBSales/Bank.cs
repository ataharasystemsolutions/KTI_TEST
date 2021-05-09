using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class Bank
    {

        [Key]
        public string BankCode { get; set; }
        public string BankName { get; set; }
    }
}