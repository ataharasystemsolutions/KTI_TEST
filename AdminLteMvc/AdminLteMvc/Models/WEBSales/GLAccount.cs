using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class GLAccount
    {
        [Key]
        public string AcctCode { get; set; }
        public string AcctName { get; set; }
        public int Levels { get; set; }
        public decimal Balance { get; set; }
        public string FatherNum { get; set; }
        public int GroupMask { get; set; }
        public int GroupLine { get; set; }
        public bool Active { get; set; }
        public bool Postable { get; set; }
    }
}