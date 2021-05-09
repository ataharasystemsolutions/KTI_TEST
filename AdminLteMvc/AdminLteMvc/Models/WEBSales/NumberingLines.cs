using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class NumberingLines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public string ObjectCode { get; set; }
        public int Series { get; set; }
        public string SeriesName { get; set; }
        public int? InitialNum { get; set; }
        public int? NextNumber { get; set; }
        public string BeginStr { get; set; }
        public string EndStr { get; set; }
        public string Remark { get; set; }
        public int? Numsize { get; set; }
        public bool Locked { get; set; }
        public string DocSubType { get; set; }
    }
}