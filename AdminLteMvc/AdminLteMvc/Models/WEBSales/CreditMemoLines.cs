using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class CreditMemoLines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int DocEntry { get; set; }
        public virtual CreditMemo VDocEntry { get; set; }
        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "Item Description can't be empty.")]
        public string Dscription { get; set; }
        public string GLAccount { get; set; }
        [Required(ErrorMessage = "LineTotal can't be empty.")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        public decimal LineTotal { get; set; }
    }
}