using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.Class
{
    public class getconsigneeDet
    {
        public string shipper { get; set; }
        public string contactperson { get; set; }
        public string consigneeName { get; set; }
        public string transactionNo { get; set; }
        public string issuedDate { get; set; }
        public string xpireDate { get; set; }
        public string PackedAs { get; set; }
        public string proformaBillRefNo { get; set; }
        
        public string ConVanFlatRackNo { get; set; }
        public string Qty { get; set; }
        public string Unit { get; set; }
        public string CargoType { get; set; }
        public string CargoDetails { get; set; }


        public string serviceMode { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string VesselVoyage { get; set; }
        public string payMode { get; set; }
        

    }
}