using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class AccomInvoiceInst
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int DocEntry { get; set; }
        public virtual AccomInvoice VDocEntry { get; set; }
        public int InstllmntID { get; set; }
        public DateTime DueDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal InsTotal { get; set; }
        public decimal InsPrcnt { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal PaidToDate { get; set; }
    }
}