using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class onboardVesselVoyageRoute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int routeID { get; set; }
        public int onboardID { get; set; }
        public int voyageLegID { get; set; }
        public int userID { get; set; }
        public DateTime? dateCreated { get; set; }
        public string voyageLegName { get; set; }
        public string portofOrigin { get; set; }
        public string portofDestination { get; set; }
        public string ATD { get; set; }
        public string ATA { get; set; }
        public string status { get; set; }
        public int lastuserID { get; set; }
        public DateTime? lastdateChanged { get; set; }
    }
}