using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;
namespace AdminLteMvc.Models.WEBSales
{
    public class EIROutLD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int eiroID { get; set; }
        public string eirldno { get; set; }
        public string eirldstatus { get; set; }
        public string eirldidate { get; set; }
        public string eirlditime { get; set; }
        public string eirldservicetype { get; set; }
        public string eirldtransactionno { get; set; }
        public string eirldconvanno { get; set; }
        public string eirldconvanstatus { get; set; }
        public string eirldconvansize { get; set; }
        public string eirldconsignee { get; set; }
        public string eirldshipper { get; set; }
        public string eirldtruckerdestination { get; set; }
        public string eirlddriversname { get; set; }
        public string eirldplateno { get; set; }
        public string eirldrelayport { get; set; }
        public string eirldvessel { get; set; }
        public string eirldvoyageno { get; set; }
        public string eirldsealno { get; set; }
        public string eirldsealstatus { get; set; }
        public string eirldportoforigin { get; set; }
        public string eirldportofdestination { get; set; }
        public string eirldweight { get; set; }
        public string eirldvolume { get; set; }
        public string eirlddamagescode { get; set; }
        public string eirldscr { get; set; }
        public string eirldremarks { get; set; }
        public string eirldcheckerdestination { get; set; }
        public string eirldtotriptype { get; set; }
    }
}