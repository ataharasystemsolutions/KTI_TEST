using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class onboardVesselLoadItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemID { get; set; }
        public int onboardID { get; set; }
        public int billID { get; set; }
        public string billofLadingNo { get; set; }
        public int userID { get; set; }
        public DateTime? dateCreated { get; set; }
        public string status { get; set; }
        public int lastuserID { get; set; }
        public DateTime? lastdateChanged { get; set; }
    }
}