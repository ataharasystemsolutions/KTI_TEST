using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class EmployeeMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string IDNO { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        public string Company { get; set; }
        public int createUserId { get; set; }
        public DateTime? dateCreated { get; set; }
        public int changeUserId { get; set; }
        public DateTime? dateChanged { get; set; }
        public string Status { get; set; }
        public bool isUser { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        
    }
}