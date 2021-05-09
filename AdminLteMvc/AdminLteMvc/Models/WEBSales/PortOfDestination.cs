using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;


namespace AdminLteMvc.Models.WEBSales
{
    public class PortOfDestination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int podID { get; set; }
        public string destinationport { get; set; }
    }
}