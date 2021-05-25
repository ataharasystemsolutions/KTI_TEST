using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.Class
{
    public class billoflading_pulled_data
    {

        public string docNum { get; set; }
        public string transactionNo { get; set; }
        public string proformaBillShipper { get; set; }
        public string proformaBillShippersAddress { get; set; }
        public string proformaBillConsignee { get; set; }
        public string proformaBillDestination { get; set; }
        public string proformaBillConsigneesAddress { get; set; }
        public string origin { get; set; }
        public string EIRIPortOfOrigin { get; set; }
        public string EIRIRelayPort { get; set; }
        public string EIRIPortOfDestination { get; set; }
        public string destination { get; set; }
        public string EIRIServiceType { get; set; }
        public string proformaBillMarks { get; set; }
        public string proformaBillQty { get; set; }
        public string proformaBillUnit { get; set; }
        public string proformaBillDescriptionOfCargo { get; set; }
        public string proformaBillValue { get; set; }
        public string proformaBillWeight { get; set; }
        public string proformaBillMeasurement { get; set; }


        public string totalnoofcasespackages { get; set; }
        public string unitofcasespackages { get; set; }
        public string CargoType { get; set; }
        public string CargoDetails { get; set; }
        public int voyageID { get; set; }
        public string EIRIVoyageNo { get; set; }
        public string EIRIVessel { get; set; }




    }
}