using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class RequestDeliverySchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int deliveryID { get; set; }
        public DateTime? dateCreated { get; set; }
        public int userID { get; set; }


        public string shipper { get; set; }
        public string serviceType { get; set; }
        public string convanNo { get; set; }
        public string EIRONo { get; set; }
        public string EIROTransactionNoget { get; set; }

        public DateTime? latdateChanged { get; set; }
        public int lastuserID { get; set; }
        public string status { get; set; }

        public string needCro { get; set; }
        public string remarks { get; set; }

    }
}