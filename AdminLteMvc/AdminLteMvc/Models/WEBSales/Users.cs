using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class Users
    {
        [Key]
        [Required(ErrorMessage = "Field can't be empty.")]
        [Display(Name = "User Code")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Field can't be empty.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Field can't be empty.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Contact Number")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Field can't be empty.")]
        public string Branch { get; set; }

        public bool Active { get; set; }
    }
}