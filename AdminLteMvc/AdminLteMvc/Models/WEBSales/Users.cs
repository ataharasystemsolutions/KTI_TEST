using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string EmpID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string userType { get; set; }
        public int createUserId{ get; set; }
        public DateTime? dateCreated { get; set; }
        public DateTime? latsDateLogin { get; set; }
        public bool active { get; set; }
    }
}