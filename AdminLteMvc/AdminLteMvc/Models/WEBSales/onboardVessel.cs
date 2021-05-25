using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class onboardVessel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int onboardID { get; set; }
        public DateTime? dateCreated { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string vessleName { get; set; }
        public string voyageNo { get; set; }
        public int vesselID { get; set; }
        public int voyageID { get; set; }
        public string status { get; set; }
        public int lastuserID { get; set; }
        public DateTime? lastdateChanged { get; set; }

    }
}