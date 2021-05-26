using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class FinalBilling
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int billID { get; set; }
        public int eirinID { get; set; }
        public string eirinNo { get; set; }
        public string billofladingNo { get; set; }
        public string bookingNo { get; set; }
        public string transactionNo { get; set; }
       
        public string vesselVoyage { get; set; }
        public string shipperName { get; set; }
        public string shipperAdd { get; set; }
        public string consigneeName { get; set; }
        public string consigneeAdd { get; set; }
        public string notifypartName { get; set; }
        public string notifypartAdd { get; set; }
        public string origin { get; set; }
        public string portoforigin { get; set; }
        public string relayPort { get; set; }
        public string portofDestination { get; set; }
        public string finalDestination { get; set; }
        public string vesselName { get; set; }
        public string voyageNumber { get; set; }
        public string serviceMode { get; set; }
        public string cargoTypeorcontent { get; set; }
        public string issuedby { get; set; }
        public DateTime? dateIssued { get; set; }
        public string timeIssued { get; set; }
        public string placeIssued { get; set; }
        public string BillStatus { get; set; }
        public  int userID { get; set; }
        public int lastUserID { get; set; }
        public DateTime? lastdatechange { get; set; }
        public string billingReferenceNo { get; set; }
        public int voyageID { get; set; }
        public string voyageLeg { get; set; }

    }
}