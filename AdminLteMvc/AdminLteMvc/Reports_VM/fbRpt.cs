using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Reports_VM
{
    public class fbRpt
    {
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
        public DateTime dateIssued { get; set; }

        public string mark { get; set; }
        public string qty { get; set; }
        public string unit { get; set; }
        public string description { get; set; }
        public string value { get; set; }
        public string weight { get; set; }
        public string measurement { get; set; }
        public int lastUserId { get; set; }
        public int lastchange { get; set; }
        public string status { get; set; }

        public string shipper { get; set; }
        public string consignee { get; set; }
        public string notify { get; set; }
        public string Date_issued { get; set; }

        public string Time_Issued { get; set; }
        public string EIRIConvanNo { get; set; }
        public string EIRISealNo { get; set; }
        public string EIRIRemarks { get; set; }
        public string placeIssued { get; set; }

        
    }
}