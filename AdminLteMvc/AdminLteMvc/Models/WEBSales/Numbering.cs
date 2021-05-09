using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class Numbering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocEntry { get; set; }
        public string ObjectCode { get; set; }
        public int AutoKey { get; set; }
        public int DfltSeries { get; set; }
        public string DocAlias { get; set; }
 
    }
}