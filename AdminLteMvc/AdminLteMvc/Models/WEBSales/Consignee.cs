using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;
namespace AdminLteMvc.Models.WEBSales
{
    public class Consignee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string consignee { get; set; }
        public string consigneeaddress { get; set; }
        public string consigneecontactno { get; set; }
    }
}