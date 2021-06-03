using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Reports_VM
{
    public class YardVessellLoadList
    {
        public int onboardID  { get; set; }
        public string vessleName { get; set; }
        public string voyageNo { get; set; }
        public string vesselName { get; set; }
        public string voyageNumber { get; set; }
        public string voyageLeg { get; set; }
        public string billofladingNo { get; set; }
        public string EIRIConvanNo { get; set; }
        public string EIRISealNo { get; set; }
        public string shipperName { get; set; }
        public string shipperAdd { get; set; }
        public string origin { get; set; }
        public string portoforigin { get; set; }
        public string portofDestination { get; set; }
        public string finalDestination { get; set; }
        public string consigneeName { get; set; }
        public string serviceMode { get; set; }
        public string CargoDetails { get; set; }
        public string EIRIConvanStatus { get; set; }



        public string cargoTypeorcontent { get; set; }
        public string datepacked { get; set; }
        public string totalnoofcasespackages { get; set; }
        public string unitofcasespackages { get; set; }
        public string PackedAs { get; set; }
        public string ShipmentDocumentNumber { get; set; }

        public string consigneeAdd { get; set; }




        public string proformaBillValue { get; set; }
        public string proformaBillWeight { get; set; }
        public string proformaBillMeasurement { get; set; }
        public string ATA { get; set; }
        public string ATD { get; set; }



    }
}