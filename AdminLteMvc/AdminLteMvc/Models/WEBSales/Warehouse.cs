using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class Warehouse
    {
        [Key]
        [Display(Name = "Warehouse Code")]
        [Required(ErrorMessage = "Warehouse Code can't be empty.")]
        public string WhsCode { get; set; }
        [Display(Name = "Warehouse Name")]
        [Required(ErrorMessage = "Warehouse Name can't be empty.")]
        public string WhsName { get; set; }
        public string Branch { get; set; }
        public bool Active { get; set; }
    }
}