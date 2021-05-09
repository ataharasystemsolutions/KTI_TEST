using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class IncomingChecks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int DocEntry { get; set; }
        public virtual Incoming VDocEntry { get; set; }
        public DateTime DueDate { get; set; }
        public string CheckNum { get; set; }
        public string BankCode { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal CheckSum { get; set; }
    }
}