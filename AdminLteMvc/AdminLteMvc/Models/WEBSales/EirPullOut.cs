using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class EirPullOut
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EIROID { get; set; }      
        public string EIRONo { get; set; }
        public string EIROAtwBkNo { get; set; }
        public string EIRODate { get; set; }
        public string EIROTime { get; set; }
        public string EIROServiceType { get; set; }
        public string EIROConvanStatus { get; set; }
        public string EIROTransactionNo { get; set; }
        public string EIROVessel { get; set; }
        public string EIROVoyageNo { get; set; }
        public string EIROPortOfOrigin { get; set; }
        public string EIRORelayPort { get; set; }
        public string EIROPortOfDestination { get; set; }
        public string EIROConvanNo { get; set; }
        public string EIROSealNo { get; set; }
        public string EIROSealStatus { get; set; }
        public string EIROConvanSize { get; set; }
        public string EIROWeight { get; set; }
        public string EIROVolume { get; set; }
        public string EIROShipper { get; set; }
        public string EIROConsignee { get; set; }
        public string EIROTrucker { get; set; }
        public string EIROPlateNo { get; set; }
        public string EIRODriversName { get; set; }
        public string EIRODamagesCode { get; set; }
        public string EIROSCR { get; set; }
        public string EIROStatus { get; set; }
        public string EIRORemarks { get; set; }
        
    }
}