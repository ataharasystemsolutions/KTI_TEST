using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class ReplacementSN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int DocEntry { get; set; }
        public virtual Replacement VDocEntry { get; set; }
        public int? DocLine { get; set; }
        public string ItemCode { get; set; }
        public string MnfSerialNo { get; set; }
        public string SerialNo { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public string Color { get; set; }
        public string FrameNo { get; set; }
    }
}