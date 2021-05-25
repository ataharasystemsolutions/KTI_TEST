using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class TransactionDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tranID { get; set; }
        public string documentID { get; set; }
        public int transactionID { get; set; }
        public string transactionNo { get; set; }
        public string dtlStatus { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string consignee1 { get; set; }
        public string consignee2 { get; set; }
        public string consignee3 { get; set; }
        public string consignee4 { get; set; }
        public string consignee5 { get; set; }
        public string consignee6 { get; set; }
        public string consignee7 { get; set; }
        public string consignee8 { get; set; }
        public string consignee9 { get; set; }
        public string consignee10 { get; set; }
        public string cnameshipper { get; set; }
        public string consigneeAdd1 { get; set; }
        public string consigneeAdd2 { get; set; }
        public string consigneeAdd3 { get; set; }
        public string consigneeAdd4 { get; set; }
        public string consigneeAdd5 { get; set; }
        public string consigneeAdd6 { get; set; }
        public string consigneeAdd7 { get; set; }
        public string consigneeAdd8 { get; set; }
        public string consigneeAdd9 { get; set; }
        public string consigneeAdd10 { get; set; }
        public string consigneetelno1 { get; set; }
        public string consigneetelno2 { get; set; }
        public string consigneetelno3 { get; set; }
        public string consigneetelno4 { get; set; }
        public string consigneetelno5 { get; set; }
        public string consigneetelno6 { get; set; }
        public string consigneetelno7 { get; set; }
        public string consigneetelno8 { get; set; }
        public string consigneetelno9 { get; set; }
        public string consigneetelno10 { get; set; }
        public string booktype { get; set; }
        public string conClass { get; set; }
        public string conRqrmnts { get; set; }
        public string quantity { get; set; }
        public string payMode { get; set; }
        public string cyEPO { get; set; }
        public string cySA { get; set; }
        public string cyLD { get; set; }
        public string remarks { get; set; }
        public string serviceType { get; set; }
        public string transactionDate { get; set; }
        public string docNumber { get; set; }
        public string consize { get; set; }
        public string chargee { get; set; }
        public string convanno { get; set; }
        public int atwID { get; set; }
        public string outStatus { get; set; }
        public string confirmStatus { get; set; }
    }
}