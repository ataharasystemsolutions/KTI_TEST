using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.Class
{
    public class tmpIncomingLines
    {
        public int DocNum { get; set; }
        public string DocType { get; set; }
        public int InstNum { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        public int OverDue { get; set; }
        public string Remarks { get; set; }
        public decimal DocTotal { get; set; }
        public decimal Balance { get; set; }
        public decimal? Discount { get; set; }
        public decimal Payment { get; set; }
    }
}