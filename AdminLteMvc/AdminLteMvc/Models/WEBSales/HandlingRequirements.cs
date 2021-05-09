using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class HandlingRequirements
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int handlingReqID { get; set; }
        public int userID { get; set; }
        public DateTime? dateCreated { get; set; }
        public string description { get; set; }
        public string status { get; set; }

        public int lastuserID { get; set; }
        public DateTime? lastdateChange { get; set; }

    }
}