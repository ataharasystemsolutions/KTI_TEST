using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Reports_VM
{
    public class ATWVm
    {
            public string AuthorizedTrucker { get; set; }
            public string AuthorizedDriver { get; set; }
            public string CompanyShipper { get; set; }
            public string ContactPerson { get; set; }
            public string ATWBookingNo { get; set; }
            public string TruckPlateNo { get; set; }
            public string Booking { get; set; }
            public string IssueDate { get; set; }
            public string ExpiryDate { get; set; }
            public string Consignee { get; set; }
            public string Cargo { get; set; }
            public string ServiceMode { get; set; }
            public string CYPullOut { get; set; }
            public string CYStuffing { get; set; }
            public string CYDelivery { get; set; }
            public string ConVanRequirements { get; set; }
            public string TransactionNo { get; set; }
            public string Origin { get; set; }
            public string Destination { get; set; }
            public string Remarks { get; set; }
            public string ConVanSize { get; set; }
            public string ConVanStatus { get; set; }
    }
}