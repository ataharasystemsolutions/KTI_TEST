using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.Class
{
    public class pulledCRODATA
    {



        public string shipper { get; set; }
        public string shipperContactPerson { get; set; }
        public string consignee { get; set; }
        public string AuthorizedDriverDestination { get; set; }
        public string AuthorizedTruckerDestination { get; set; }
        public string AuthorizedTruckPlateNoDestination { get; set; }
        public string croSerial { get; set; }
        public string issueDate { get; set; }
        public string expyreDate { get; set; }
        public string CYPullofOutofCargoLadenConVan { get; set; }
        public string CYStuffingStripping { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public string CargoDesciption { get; set; }
        public string OtherCargoDetails { get; set; }
        public string ServiceMode { get; set; }
        public string PackedAs { get; set; }
        public string Origin { get; set; }
        public string destination { get; set; }
        public string VesselVoyage { get; set; }
        public string SpecialHandlingRequirement { get; set; }
        public string Remarks { get; set; }
        public string IssuedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string paymentTerms { get; set; }

    }
}