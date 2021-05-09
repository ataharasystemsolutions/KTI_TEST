using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class EIRINECV
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int eirinecvID { get; set; }
        public string eirinecvno { get; set; }
        public string eirinecvreferenceno { get; set; }
        public string eirinecvstatus { get; set; }
        public string eirinecvidate { get; set; }
        public string eirinecvitime { get; set; }
        public string eirinecvservicetype { get; set; }
        public string eirinecvtransactionno { get; set; }
        public string eirinecvconvanno { get; set; }
        public string eirinecvconvanstatus { get; set; }
        public string eirinecvconvansize { get; set; }
        public string eirinecvconsignee { get; set; }
        public string eirinecvshipper { get; set; }
        public string eirinecvtrucker { get; set; }
        public string eirinecvdriversname { get; set; }
        public string eirinecvplateno { get; set; }
        public string eirinecvrelayport { get; set; }
        public string eirinecvvessel { get; set; }
        public string eirinecvvoyageno { get; set; }
        public string eirinecvsealno { get; set; }
        public string eirinecvsealstatus { get; set; }
        public string eirinecvportoforigin { get; set; }
        public string eirinecvportofdestination { get; set; }
        public string eirinecvweight { get; set; }
        public string eirinecvvolume { get; set; }
        public string eirinecvdamagescode { get; set; }
        public string eirinecvscr { get; set; }
        public string eirinecvremarks { get; set; }
        public string eirinecvtriptype { get; set; }
        public string eirinecvwaybillno { get; set; }
        public string eirinecvwaybillattachement { get; set; }
    }
}