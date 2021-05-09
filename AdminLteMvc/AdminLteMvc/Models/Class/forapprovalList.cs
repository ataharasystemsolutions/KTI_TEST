using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.Class
{
    public class forapprovalList
    {
        public string shipper { get; set; }
        public string serviceType { get; set; }
        public string convanNo { get; set; }
        public string consigneeName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string Status { get; set; }
        public int consigneeId { get; set; }
    }
}