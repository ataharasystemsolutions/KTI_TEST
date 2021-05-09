using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class SerialMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int SysNumber { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string DistNumber { get; set; }
        public string MnfSerial { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantOut { get; set; }
        public decimal Balance { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public string Color { get; set; }
        public string FrameNo { get; set; }
    }
}