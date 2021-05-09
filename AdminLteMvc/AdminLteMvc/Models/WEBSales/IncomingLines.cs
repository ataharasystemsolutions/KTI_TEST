using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class IncomingLines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int DocEntry { get; set; }
        public virtual Incoming VDocEntry { get; set; }
        public int InstNum { get; set; }
        public int DocNum { get; set; }
        public string InvType { get; set; }
        public int OverDueDays { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal SumApplied { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal? Discount { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal DocTotal { get; set; }
    }
}