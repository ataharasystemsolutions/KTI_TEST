using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class RequestDeliveryScheduleConsignee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int consigneeId { get; set; }
        public int deliveryID { get; set; }

        public string consigneeName { get; set; }
        public string consigneeAddress { get; set; }
        public string consigneeContact { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string Action { get; set; }
        public string Status { get; set; }

    }
}