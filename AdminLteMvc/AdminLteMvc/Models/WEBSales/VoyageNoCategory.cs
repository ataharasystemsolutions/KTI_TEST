using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class VoyageNoCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryID { get; set; }
        public int voyageID { get; set; }
        public string category { get; set; }
        public string portOrigin { get; set; }
        public string portDestination { get; set; }
        public int lastuserId { get; set; }
        public DateTime? lastChange { get; set; }
        public string status { get; set; }
    }
}