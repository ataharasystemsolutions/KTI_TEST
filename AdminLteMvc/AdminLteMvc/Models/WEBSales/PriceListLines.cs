using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.WEBSales
{
    public class PriceListLines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }
        public int PriceListID { get; set; }
        public virtual PriceList VPriceListID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal AF { get; set; }
        public decimal DPYT1 { get; set; }
        public decimal BPrice { get; set; }
        public decimal SCash { get; set; }
        public decimal LCP { get; set; }
        public decimal DPYT2 { get; set; }
        public decimal Mos1 { get; set; }
        public decimal Mos2 { get; set; }
        public decimal Mos3 { get; set; }
        public decimal Mos4 { get; set; }
        public decimal Mos5 { get; set; }
        public decimal Mos6 { get; set; }
        public decimal Mos7 { get; set; }
        public decimal Mos8 { get; set; }
        public decimal Mos9 { get; set; }
        public decimal Mos10 { get; set; }
        public decimal Mos11 { get; set; }
        public decimal Mos12 { get; set; }
        public decimal Mos13 { get; set; }
        public decimal Mos14 { get; set; }
        public decimal Mos15 { get; set; }
        public decimal Mos16 { get; set; }
        public decimal Mos17 { get; set; }
        public decimal Mos18 { get; set; }
        public decimal Mos19 { get; set; }
        public decimal Mos20 { get; set; }
        public decimal Mos21 { get; set; }
        public decimal Mos22 { get; set; }
        public decimal Mos23 { get; set; }
        public decimal Mos24 { get; set; }
        public decimal Mos25 { get; set; }
        public decimal Mos26 { get; set; }
        public decimal Mos27 { get; set; }
        public decimal Mos28 { get; set; }
        public decimal Mos29 { get; set; }
        public decimal Mos30 { get; set; }
        public decimal Mos31 { get; set; }
        public decimal Mos32 { get; set; }
        public decimal Mos33 { get; set; }
        public decimal Mos34 { get; set; }
        public decimal Mos35 { get; set; }
        public decimal Mos36 { get; set; }
        public decimal Rebate { get; set; }
        public decimal CM { get; set; }
        public decimal FH { get; set; }
        public decimal CashBack { get; set; }
        public decimal Charges { get; set; }
        public decimal COD { get; set; }
        public decimal Reg { get; set; }
        public int HP { get; set; }
    }
}