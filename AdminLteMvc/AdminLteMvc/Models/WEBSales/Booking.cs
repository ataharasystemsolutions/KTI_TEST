using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string docYear { get; set; }
        public string docID { get; set; }
        public string docDate { get; set; }
        public string inhouseBookingDate { get; set; }
        public string docNum { get; set; }
        public string billTo { get; set; }
        public string mnemonic { get; set; }
        public string cnameshpr { get; set; }
        public string shipperAddress { get; set; }
        public string shipperTelNo { get; set; }
        public string csize { get; set; }
        public string cstatus { get; set; }
        public string transactionNo { get; set; }
        public string trnStatus { get; set; }
        public string preparedBy { get; set; }
        public string contactperson { get; set; }
        public string contactno { get; set; }
        public string noofcvs { get; set; }
        public string inputtedby { get; set; }
        public string csr { get; set; }
        public string accountexecutive { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> TransactionNumbers { get; set; }
    }   
}