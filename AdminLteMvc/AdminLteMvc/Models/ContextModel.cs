using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models
{
    public class ContextModel : DbContext
    {
        public ContextModel()
            : base("DefaultConnection")
        {
        }

        public DbSet<WEBSales.Users> Users { get; set; }
        public DbSet<WEBSales.PriceList> PriceLists { get; set; }
        public DbSet<WEBSales.PriceListLines> PriceListLines { get; set; }
        public DbSet<WEBSales.PriceListBranch> PriceListBranches { get; set; }
        public DbSet<WEBSales.SalesEmployee> SalesEmployees { get; set; }
        public DbSet<WEBSales.EmployeeMaster> EmployeeMasters { get; set; }
        public DbSet<WEBSales.Warehouse> Warehouses { get; set; }
        public DbSet<WEBSales.VatGroup> VatGroups { get; set; }
        public DbSet<WEBSales.CostCenter> CostCenters { get; set; }
        public DbSet<WEBSales.Project> Projects { get; set; }
        public DbSet<WEBSales.PaymentTerms> PaymentTerms { get; set; }
        public DbSet<WEBSales.BusinessPartner> BusinessPartners { get; set; }
        public DbSet<WEBSales.Comaker> CoMakers { get; set; }
        public DbSet<WEBSales.Items> Items { get; set; }
        public DbSet<WEBSales.Inventory> Inventories { get; set; }
        public DbSet<WEBSales.BPWithHolding> BPWithHoldings { get; set; }
        public DbSet<WEBSales.GLAccount> GLAccounts { get; set; }
        public DbSet<WEBSales.SerialMaster> SerialMasters { get; set; }
        public DbSet<WEBSales.WithHoldings> WithHoldings { get; set; }
        public DbSet<WEBSales.Numbering> Numberings { get; set; }
        public DbSet<WEBSales.NumberingLines> NumberingLines { get; set; }
        public DbSet<WEBSales.ItemGroup> ItemGroups { get; set; }
        public DbSet<WEBSales.Bank> Banks { get; set; }
        public DbSet<WEBSales.CreditCard> CreditCards { get; set; }

        public DbSet<WEBSales.SalesOrder> SalesOrders { get; set; }
        public DbSet<WEBSales.SalesOrderLines> SalesOrderLines { get; set; }
        public DbSet<WEBSales.SalesOrderSN> SalesOrderSNs { get; set; }


        public DbSet<WEBSales.CashInvoice> CashInvoices { get; set; }
        public DbSet<WEBSales.CashInvoiceLines> CashInvoiceLines { get; set; }
        public DbSet<WEBSales.CashInvoiceSN> CashInvoiceSNs { get; set; }
        public DbSet<WEBSales.CashInvoiceWtax> CashInvoiceWTaxes { get; set; }

        public DbSet<WEBSales.SalesInvoice> SalesInvoices { get; set; }
        public DbSet<WEBSales.SalesInvoiceLines> SalesInvoiceLines { get; set; }
        public DbSet<WEBSales.SalesInvoiceSN> SalesInvoiceSNs { get; set; }
        public DbSet<WEBSales.SalesInvoiceInst> SalesInvoiceInsts { get; set; }
        public DbSet<WEBSales.SalesInvoiceWTax> SalesInvoiceWTaxes { get; set; }
        public DbSet<WEBSales.SalesInvoicePL> SalesInvoicePLs { get; set; }

        public DbSet<WEBSales.CreditMemo> CreditMemoes { get; set; }
        public DbSet<WEBSales.CreditMemoLines> CreditMemoLines { get; set; }

        public DbSet<WEBSales.DPInvoice> DPInvoices { get; set; }
        public DbSet<WEBSales.DPInvoiceLines> DPInvoiceLines { get; set; }

        public DbSet<WEBSales.AccomInvoice> AccomInvoices { get; set; }
        public DbSet<WEBSales.AccomInvoiceInst> AccomInvoiceInsts { get; set; }
        public DbSet<WEBSales.AccomInvoiceLines> AccomInvoiceLines { get; set; }
        public DbSet<WEBSales.AccomInvoiceSN> AccomInvoiceSNs { get; set; }
        public DbSet<WEBSales.AccomInvoiceWTax> AccomInvoiceWTaxes { get; set; }


        public DbSet<WEBSales.Incoming> Incomings { get; set; }
        public DbSet<WEBSales.IncomingLines> IncomingLines { get; set; }
        public DbSet<WEBSales.IncomingCards> IncomingCards { get; set; }
        public DbSet<WEBSales.IncomingChecks> IncomingChecks { get; set; }

        public DbSet<WEBSales.GoodsReceipt> GoodsReceipts { get; set; }
        public DbSet<WEBSales.GoodsReceiptLines> GoodsReceiptLines { get; set; }
        public DbSet<WEBSales.GoodsReceiptSN> GoodsReceiptSNs { get; set; }

        public DbSet<WEBSales.WarrantyReturns> WarrantyReturns { get; set; }
        public DbSet<WEBSales.WarrantyReturnLines> WarrantyReturnLines { get; set; }
        public DbSet<WEBSales.WarrantyReturnSN> WarrantyReturnSNs { get; set; }

        public DbSet<WEBSales.OtherGoodsReceipt> OtherGoodsReceipts { get; set; }
        public DbSet<WEBSales.OtherGoodsReceiptLines> OtherGoodsReceiptLines { get; set; }
        public DbSet<WEBSales.OtherGoodsReceiptSN> OtherGoodsReceiptSNs { get; set; }

        public DbSet<WEBSales.InvTransfer> InvTransfers { get; set; }
        public DbSet<WEBSales.InvTransferLines> InvTransferLines { get; set; }

        public DbSet<WEBSales.BranchReceiving> BranchReceivings { get; set; }
        public DbSet<WEBSales.BranchReceivingLines> BranchReceivingLines { get; set; }
        public DbSet<WEBSales.BranchReceivingSN> BranchReceivingSNs { get; set; }

        public DbSet<WEBSales.GoodsIssue> GoodsIssues { get; set; }
        public DbSet<WEBSales.GoodsIssueLines> GoodsIssueLines { get; set; }
        public DbSet<WEBSales.GoodsIssueSN> GoodsIssueSNs { get; set; }

        public DbSet<WEBSales.WarrantyRepair> WarrantyRepairs { get; set; }
        public DbSet<WEBSales.WarrantyRepairLines> WarrantyRepairLines { get; set; }
        public DbSet<WEBSales.WarrantyRepairSN> WarrantyRepairSNs { get; set; }

        public DbSet<WEBSales.ChangeUnit> ChangeUnits { get; set; }
        public DbSet<WEBSales.ChangeUnitLines> ChangeUnitLines { get; set; }
        public DbSet<WEBSales.ChangeUnitSN> ChangeUnitSNs { get; set; }

        public DbSet<WEBSales.OtherGoodsIssue> OtherGoodsIssues { get; set; }
        public DbSet<WEBSales.OtherGoodsIssueLines> OtherGoodsIssueLines { get; set; }
        public DbSet<WEBSales.OtherGoodsIssueSN> OtherGoodsIssueSN { get; set; }

        public DbSet<WEBSales.Replacement> Replacements { get; set; }
        public DbSet<WEBSales.ReplacementLines> ReplacementLines { get; set; }
        public DbSet<WEBSales.ReplacementSN> ReplacementSNs { get; set; }
        public DbSet<WEBSales.Booking> Booking { get; set; }
        public DbSet<WEBSales.TransactionDetails> TransactionDetails { get; set; }
        public DbSet<WEBSales.ATW> ATW { get; set; }
        public DbSet<WEBSales.ATWDetails> ATWDetails { get; set; }

        public DbSet<WEBSales.Mnemonics> Mnemonics { get; set; }
        public DbSet<WEBSales.CustomerShippers> CustomerShippers { get; set; }

        public DbSet<WEBSales.ConVanSizes> ConVanSizes { get; set; }
        public DbSet<WEBSales.ConVanStatus> ConVanStatus { get; set; }

        public DbSet<WEBSales.PriceGroup> PriceGroup { get; set; }
        public DbSet<WEBSales.Origin> Origin { get; set; }
        public DbSet<WEBSales.Destination> Destination { get; set; }
        public DbSet<WEBSales.Consignee> Consignee { get; set; }
        public DbSet<WEBSales.ServiceType> ServiceType { get; set; }
        public DbSet<WEBSales.ChargeTo> ChargeTo { get; set; }

        public DbSet<WEBSales.CargoType> CargoType { get; set; }
        public DbSet<WEBSales.ContainerClass> ContainerClass { get; set; }
        public DbSet<WEBSales.ConVanRequirements> ConVanRequirements { get; set; }

        public DbSet<WEBSales.CYEPO> CYEPO { get; set; }
        public DbSet<WEBSales.CYSA> CYSA { get; set; }
        public DbSet<WEBSales.CYLD> CYLD { get; set; }


        public DbSet<WEBSales.Yard> Yard { get; set; }
        public DbSet<WEBSales.ConVanNo> ConVanNo { get; set; }
        public DbSet<WEBSales.AssignedBy> AssignedBy { get; set; }
        public DbSet<WEBSales.EirPullOut> EirPullOut { get; set; }
        public DbSet<WEBSales.EIRIn> EIRIn { get; set; }
        public DbSet<WEBSales.Vessel> Vessel { get; set; }
        public DbSet<WEBSales.VoyageNo> VoyageNo { get; set; }
        public DbSet<WEBSales.PortOfOrigin> PortOfOrigin { get; set; }
        public DbSet<WEBSales.PortOfDestination> PortOfDestination { get; set; }
        public DbSet<WEBSales.SealStatus> SealStatus { get; set; }
        public DbSet<WEBSales.DamagesCode> DamagesCode { get; set; }

        public DbSet<WEBSales.ProformaBills> ProformaBills { get; set; }

        public DbSet<WEBSales.CYLocation> CYLocation { get; set; }

        public DbSet<WEBSales.InputtedBy> InputtedBy { get; set; }
        public DbSet<WEBSales.CSR> CSR { get; set; }
        public DbSet<WEBSales.AccountExecutive> AccountExecutive { get; set; }
        public DbSet<WEBSales.PaymentMode> PaymentMode { get; set; }
        public DbSet<WEBSales.Truckers> Truckers { get; set; }
        public DbSet<WEBSales.BookingType> BookingType { get; set; }
        public DbSet<WEBSales.ATWIssuedBy> ATWIssuedBy { get; set; }

        public DbSet<WEBSales.FinalBilling> FinalBilling { get; set; }
        public DbSet<WEBSales.FinalBillingItem> FinalBillingItem { get; set; }
        
        public DbSet<WEBSales.VoyageNoCategory> VoyageNoCategory { get; set; }


       
        public DbSet<WEBSales.RequestDeliverySchedule> RequestDeliverySchedule { get; set; }
        public DbSet<WEBSales.RequestDeliveryScheduleConsignee> RequestDeliveryScheduleConsignee { get; set; }
        public DbSet<WEBSales.CRO> CRO { get; set; }


        public DbSet<WEBSales.EIROutLD> EIROutLD { get; set; }
        public DbSet<WEBSales.EIRINECV> EIRINECV { get; set; }
        public DbSet<WEBSales.UnitCases> UnitCases { get; set; }
        public DbSet<WEBSales.packedAs> packedAs { get; set; }
        public DbSet<WEBSales.HandlingRequirements> HandlingRequirements { get; set; }
    }
}