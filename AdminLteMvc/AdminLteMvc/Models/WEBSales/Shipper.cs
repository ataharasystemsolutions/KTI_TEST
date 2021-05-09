using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLteMvc.Models.WEBSales
{
    public class Shipper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int shipperID { get; set; }

        public string shprName { get; set; }
        public IEnumerable<SelectListItem> ShipperNames { get; set; }
    }
}