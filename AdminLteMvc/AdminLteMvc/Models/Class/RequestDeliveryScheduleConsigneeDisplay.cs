using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.Class
{
    public class RequestDeliveryScheduleConsigneeDisplay
    {
        public int consigneeId { get; set; }
        public int deliveryID { get; set; }

        public string consigneeName { get; set; }
        public string consigneeAddress { get; set; }
        public string consigneeContact { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string Action { get; set; }
        public string Status { get; set; }
    }
}