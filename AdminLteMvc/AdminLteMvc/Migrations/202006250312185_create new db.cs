namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createnewdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccomInvoiceInsts",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        InstllmntID = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        InsTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InsPrcnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidToDate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.AccomInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.AccomInvoices",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        CardCode = c.String(nullable: false),
                        CardName = c.String(nullable: false),
                        Status = c.String(),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        DocDueDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedTime = c.String(),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        DocTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WTaxTotal = c.Decimal(precision: 18, scale: 2),
                        PaidTodate = c.Decimal(precision: 18, scale: 2),
                        ReceiptNum = c.Int(),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Project = c.String(),
                        GroupNum = c.String(),
                        OwnerCode = c.String(),
                        SlpCode = c.String(),
                        Address = c.String(),
                        PriceList = c.Int(nullable: false),
                        Installment = c.Int(),
                        ActivityType = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                        PNIssuedNo = c.String(),
                        PNIssuedAt = c.String(),
                        PNIssuedDate = c.DateTime(),
                        CMIssuedDate = c.DateTime(),
                        InterestRate = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.AccomInvoiceLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        VatGroup = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        OpenQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseRef = c.Int(),
                        BaseType = c.String(),
                        WTLiable = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                        Dwnpayment = c.Decimal(precision: 18, scale: 2),
                        MA = c.Decimal(precision: 18, scale: 2),
                        Rebate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemType = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.AccomInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.AccomInvoiceSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.AccomInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.AccomInvoiceWTaxes",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        WTCode = c.String(),
                        WTName = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseAmnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxableAmnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WTAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                        Account = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.AccomInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankCode = c.String(nullable: false, maxLength: 128),
                        BankName = c.String(),
                    })
                .PrimaryKey(t => t.BankCode);
            
            CreateTable(
                "dbo.BPWithHoldings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CardCode = c.String(maxLength: 128),
                        WTCode = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BusinessPartners", t => t.CardCode)
                .Index(t => t.CardCode);
            
            CreateTable(
                "dbo.BusinessPartners",
                c => new
                    {
                        CardCode = c.String(nullable: false, maxLength: 128),
                        CardName = c.String(),
                        ForeignName = c.String(),
                        BPType = c.String(),
                        Type = c.String(),
                        Phone = c.String(),
                        Phone2 = c.String(),
                        Address = c.String(),
                        LicTradNum = c.String(),
                        AliasName = c.String(),
                        ProjectCode = c.String(),
                        Province = c.String(),
                        City = c.String(),
                        Baranggay = c.String(),
                        Street = c.String(),
                        ZipCode = c.String(),
                        AreaCode = c.String(),
                        Birthday = c.DateTime(),
                        Gender = c.String(),
                        CivilStatus = c.String(),
                        Occupation = c.String(),
                        Position = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        SSSNo = c.String(),
                        Cedula = c.String(),
                        DateIssued = c.DateTime(),
                        PlaceIssued = c.String(),
                        VatStatus = c.String(),
                        VatGroup = c.String(),
                        WTLiable = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Series = c.Int(nullable: false),
                        ImagePath = c.String(),
                        Photo = c.Binary(),
                        CardLName = c.String(),
                        CardFName = c.String(),
                        CardMName = c.String(),
                        ForeignFName = c.String(),
                        ForeignLName = c.String(),
                        ForeignMName = c.String(),
                    })
                .PrimaryKey(t => t.CardCode);
            
            CreateTable(
                "dbo.Comakers",
                c => new
                    {
                        ComakerID = c.Int(nullable: false, identity: true),
                        CardCode = c.String(maxLength: 128),
                        CoMakerName = c.String(),
                        CoMakerAddress = c.String(),
                        Contact = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                    })
                .PrimaryKey(t => t.ComakerID)
                .ForeignKey("dbo.BusinessPartners", t => t.CardCode)
                .Index(t => t.CardCode);
            
            CreateTable(
                "dbo.BranchReceivingLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        LineNum = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FromWhsCode = c.String(nullable: false),
                        ToWhsCode = c.String(nullable: false),
                        InfoPrice = c.Decimal(precision: 18, scale: 2),
                        Account = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.BranchReceivings", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.BranchReceivings",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        CardCode = c.String(),
                        CardName = c.String(),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        FromWhsCode = c.String(nullable: false),
                        ToWhsCode = c.String(nullable: false),
                        SlpCode = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.BranchReceivingSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.BranchReceivings", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.CashInvoiceLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        VatGroup = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        OpenQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseRef = c.Int(),
                        BaseType = c.String(),
                        WTLiable = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                        ItemType = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.CashInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.CashInvoices",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        CardCode = c.String(nullable: false),
                        CardName = c.String(nullable: false),
                        Status = c.String(),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        DocDueDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedTime = c.String(),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        DocTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WTaxTotal = c.Decimal(precision: 18, scale: 2),
                        PaidTodate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceiptNum = c.Int(),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Project = c.String(),
                        GroupNum = c.String(),
                        OwnerCode = c.String(),
                        SlpCode = c.String(),
                        Address = c.String(),
                        PriceList = c.Int(nullable: false),
                        Installment = c.Int(),
                        ActivityType = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.CashInvoiceSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.CashInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.CashInvoiceWtaxes",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        WTCode = c.String(),
                        WTName = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseAmnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxableAmnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WTAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                        Account = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.CashInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.ChangeUnitLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        LineNum = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        Account = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.ChangeUnits", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.ChangeUnits",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        UserSign = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.ChangeUnitSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.ChangeUnits", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.CostCenters",
                c => new
                    {
                        PrcCode = c.String(nullable: false, maxLength: 128),
                        PrcName = c.String(),
                        Branch = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PrcCode);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CardName = c.String(nullable: false, maxLength: 128),
                        AcctCode = c.String(),
                    })
                .PrimaryKey(t => t.CardName);
            
            CreateTable(
                "dbo.CreditMemoes",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        CardCode = c.String(nullable: false),
                        CardName = c.String(nullable: false),
                        Status = c.String(),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        DocDueDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedTime = c.String(),
                        Remarks = c.String(),
                        DocTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidTodate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Project = c.String(),
                        OwnerCode = c.String(),
                        SlpCode = c.String(),
                        PriceList = c.Int(nullable: false),
                        Installment = c.Int(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                        NumAtCard = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.CreditMemoLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        Dscription = c.String(nullable: false),
                        GLAccount = c.String(),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.CreditMemoes", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.DPInvoiceLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        VatGroup = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        OpenQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseRef = c.Int(),
                        BaseType = c.String(),
                        WTLiable = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                        Dwnpayment = c.Decimal(precision: 18, scale: 2),
                        MA = c.Decimal(precision: 18, scale: 2),
                        ItemType = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.DPInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.DPInvoices",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        CardCode = c.String(nullable: false),
                        CardName = c.String(nullable: false),
                        Status = c.String(),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        DocDueDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedTime = c.String(),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        DocTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidTodate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceiptNum = c.Int(),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Project = c.String(),
                        GroupNum = c.String(),
                        OwnerCode = c.String(),
                        SlpCode = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.EmployeeMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmpID = c.Int(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        JobTitle = c.String(),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GLAccounts",
                c => new
                    {
                        AcctCode = c.String(nullable: false, maxLength: 128),
                        AcctName = c.String(),
                        Levels = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FatherNum = c.String(),
                        GroupMask = c.Int(nullable: false),
                        GroupLine = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Postable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AcctCode);
            
            CreateTable(
                "dbo.GoodsIssueLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        LineNum = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        Account = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.GoodsIssues", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.GoodsIssues",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        UserSign = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.GoodsIssueSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.GoodsIssues", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.GoodsReceiptLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        LineNum = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        Account = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.GoodsReceipts", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.GoodsReceipts",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        CardCode = c.String(nullable: false),
                        CardName = c.String(nullable: false),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        UserSign = c.String(),
                        DocTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.GoodsReceiptSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.GoodsReceipts", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.IncomingCards",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        CreditCardCode = c.String(),
                        CreditAcc = c.String(),
                        CardNumber = c.String(),
                        CardValid = c.DateTime(nullable: false),
                        VoucherNum = c.Int(nullable: false),
                        CreditSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.Incomings", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.Incomings",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        CardCode = c.String(nullable: false),
                        CardName = c.String(nullable: false),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        DocDueDate = c.DateTime(nullable: false),
                        Reference = c.String(),
                        PrjCode = c.String(),
                        Remarks = c.String(),
                        CashAcct = c.String(),
                        TrsfrAcct = c.String(),
                        TrsfrDate = c.DateTime(),
                        TrsfrRef = c.String(),
                        CashSum = c.Decimal(precision: 18, scale: 2),
                        CreditSum = c.Decimal(precision: 18, scale: 2),
                        CheckSum = c.Decimal(precision: 18, scale: 2),
                        TrsfrSum = c.Decimal(precision: 18, scale: 2),
                        DocTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OfficialReceipt = c.String(),
                        CollectionReceipt = c.String(),
                        SIReceipt = c.String(),
                        TPReceipt = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.IncomingChecks",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        CheckNum = c.String(),
                        BankCode = c.String(),
                        CheckSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.Incomings", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.IncomingLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        InstNum = c.Int(nullable: false),
                        DocNum = c.Int(nullable: false),
                        InvType = c.String(),
                        OverDueDays = c.Int(nullable: false),
                        SumApplied = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        DocTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.Incomings", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryID = c.Int(nullable: false, identity: true),
                        ItemCode = c.String(maxLength: 128),
                        WhsCode = c.String(),
                        WhsName = c.String(),
                        OnHand = c.Int(nullable: false),
                        IsCommited = c.Int(nullable: false),
                        OnOrder = c.Int(nullable: false),
                        Locked = c.Boolean(nullable: false),
                        MinStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Branch = c.String(),
                    })
                .PrimaryKey(t => t.InventoryID)
                .ForeignKey("dbo.Items", t => t.ItemCode)
                .Index(t => t.ItemCode);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemCode = c.String(nullable: false, maxLength: 128),
                        ItemName = c.String(nullable: false),
                        FrgnName = c.String(),
                        PrchseItem = c.Boolean(nullable: false),
                        SellItem = c.Boolean(nullable: false),
                        InvntItem = c.Boolean(nullable: false),
                        Barcode = c.String(),
                        LastPurPrice = c.Decimal(precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        BuyUnitMsr = c.String(),
                        VatGroupPu = c.String(),
                        SalUnitMsr = c.String(),
                        VatGroupSa = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                        InvUnitMsr = c.String(),
                    })
                .PrimaryKey(t => t.ItemCode);
            
            CreateTable(
                "dbo.InvTransferLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        LineNum = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FromWhsCode = c.String(nullable: false),
                        ToWhsCode = c.String(nullable: false),
                        InfoPrice = c.Decimal(precision: 18, scale: 2),
                        Account = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.InvTransfers", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.InvTransfers",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        CardCode = c.String(),
                        CardName = c.String(),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        FromWhsCode = c.String(nullable: false),
                        ToWhsCode = c.String(nullable: false),
                        SlpCode = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.InvTransferSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.InvTransfers", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.ItemGroups",
                c => new
                    {
                        ItemGrpID = c.Int(nullable: false, identity: true),
                        ItemGrpCode = c.Int(nullable: false),
                        ItemGrpName = c.String(),
                    })
                .PrimaryKey(t => t.ItemGrpID);
            
            CreateTable(
                "dbo.NumberingLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        ObjectCode = c.String(),
                        Series = c.Int(nullable: false),
                        SeriesName = c.String(),
                        InitialNum = c.Int(),
                        NextNumber = c.Int(),
                        BeginStr = c.String(),
                        EndStr = c.String(),
                        Remark = c.String(),
                        Numsize = c.Int(),
                        Locked = c.Boolean(nullable: false),
                        DocSubType = c.String(),
                    })
                .PrimaryKey(t => t.LineID);
            
            CreateTable(
                "dbo.Numberings",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        ObjectCode = c.String(),
                        AutoKey = c.Int(nullable: false),
                        DfltSeries = c.Int(nullable: false),
                        DocAlias = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.OtherGoodsIssueLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        LineNum = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        Account = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.OtherGoodsIssues", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.OtherGoodsIssues",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        UserSign = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.OtherGoodsIssueSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.OtherGoodsIssues", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.OtherGoodsReceiptLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        LineNum = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        Account = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.OtherGoodsReceipts", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.OtherGoodsReceipts",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        UserSign = c.String(),
                        DocTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.OtherGoodsReceiptSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.OtherGoodsReceipts", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.PaymentTerms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupNum = c.Int(nullable: false),
                        PymntGrp = c.String(),
                        ExtraMonth = c.Int(nullable: false),
                        ExtraDays = c.Int(nullable: false),
                        InstNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PaymentTermLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        IntsNo = c.Int(nullable: false),
                        InstMonth = c.Int(nullable: false),
                        InstDays = c.Int(nullable: false),
                        InstPrcnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.PaymentTerms", t => t.ID, cascadeDelete: true)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.PriceListBranches",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        PriceListID = c.Int(nullable: false),
                        PrjCode = c.String(),
                        PrjName = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.PriceLists", t => t.PriceListID, cascadeDelete: true)
                .Index(t => t.PriceListID);
            
            CreateTable(
                "dbo.PriceLists",
                c => new
                    {
                        PriceListID = c.Int(nullable: false, identity: true),
                        PriceListName = c.String(nullable: false),
                        Preparedby = c.String(),
                        ItemGroup = c.String(),
                        Validfrom = c.DateTime(nullable: false),
                        Validto = c.DateTime(nullable: false),
                        Approvedby = c.String(),
                        Notes = c.String(),
                        LCP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AnnualRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceListType = c.String(),
                    })
                .PrimaryKey(t => t.PriceListID);
            
            CreateTable(
                "dbo.PriceListLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        PriceListID = c.Int(nullable: false),
                        ItemCode = c.String(),
                        ItemName = c.String(),
                        AF = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DPYT1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SCash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LCP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DPYT2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos7 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos8 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos9 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos10 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos11 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos12 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos13 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos14 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos15 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos16 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos17 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos18 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos19 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos20 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos21 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos22 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos23 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos24 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos25 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos26 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos27 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos28 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos29 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos30 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos31 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos32 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos33 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos34 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos35 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos36 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rebate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FH = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CashBack = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Charges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        COD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reg = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.PriceLists", t => t.PriceListID, cascadeDelete: true)
                .Index(t => t.PriceListID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ProjectCode = c.String(),
                        ProjectName = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.ReplacementLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        LineNum = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        Account = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.Replacements", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.Replacements",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        UserSign = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.ReplacementSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.Replacements", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.SalesEmployees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SAPID = c.Int(nullable: false),
                        SlpName = c.String(),
                        Active = c.Boolean(nullable: false),
                        Mobile = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SalesInvoiceInsts",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        InstllmntID = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        InsTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InsPrcnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidToDate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.SalesInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.SalesInvoices",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        CardCode = c.String(nullable: false),
                        CardName = c.String(nullable: false),
                        Status = c.String(),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        DocDueDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedTime = c.String(),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        DocTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WTaxTotal = c.Decimal(precision: 18, scale: 2),
                        PaidTodate = c.Decimal(precision: 18, scale: 2),
                        DpmntAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceiptNum = c.Int(),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Project = c.String(),
                        GroupNum = c.String(),
                        OwnerCode = c.String(),
                        SlpCode = c.String(),
                        Address = c.String(),
                        PriceList = c.Int(nullable: false),
                        Installment = c.Int(),
                        ActivityType = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                        PNIssuedNo = c.String(),
                        PNIssuedAt = c.String(),
                        PNIssuedDate = c.DateTime(),
                        CMIssuedDate = c.DateTime(),
                        InterestRate = c.Decimal(precision: 18, scale: 2),
                        Assignee = c.String(),
                        DRNo = c.String(),
                        SINo = c.String(),
                        CINo = c.String(),
                        WRNo = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.SalesInvoiceLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        VatGroup = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        OpenQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseRef = c.Int(),
                        BaseType = c.String(),
                        WTLiable = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                        Dwnpayment = c.Decimal(precision: 18, scale: 2),
                        MA = c.Decimal(precision: 18, scale: 2),
                        Rebate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemType = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.SalesInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.SalesInvoicePLs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        PriceListID = c.Int(nullable: false),
                        ItemCode = c.String(),
                        ItemName = c.String(),
                        AF = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DPYT1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SCash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LCP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DPYT2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos7 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos8 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos9 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos10 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos11 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos12 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos13 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos14 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos15 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos16 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos17 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos18 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos19 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos20 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos21 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos22 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos23 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos24 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos25 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos26 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos27 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos28 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos29 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos30 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos31 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos32 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos33 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos34 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos35 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mos36 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rebate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FH = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CashBack = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Charges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        COD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reg = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.SalesInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.SalesInvoiceSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.SalesInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.SalesInvoiceWTaxes",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        WTCode = c.String(),
                        WTName = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseAmnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxableAmnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WTAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                        Account = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.SalesInvoices", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.SalesOrderLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        LineNum = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        VatGroup = c.String(),
                        Dwnpayment = c.Decimal(precision: 18, scale: 2),
                        MA = c.Decimal(precision: 18, scale: 2),
                        Project = c.String(),
                        OcrCode = c.String(),
                        OpenQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ManSerNum = c.Boolean(nullable: false),
                        Rebate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemType = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.SalesOrders", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        CardCode = c.String(nullable: false),
                        CardName = c.String(nullable: false),
                        Status = c.String(),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        DocDueDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedTime = c.String(),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        DocTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        DpmntAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Project = c.String(),
                        GroupNum = c.String(),
                        OwnerCode = c.String(),
                        SlpCode = c.String(),
                        Address = c.String(),
                        PNIssuedNo = c.String(),
                        PNIssuedAt = c.String(),
                        PNIssuedDate = c.DateTime(),
                        CMIssuedDate = c.DateTime(),
                        InterestRate = c.Decimal(precision: 18, scale: 2),
                        PriceList = c.Int(nullable: false),
                        Installment = c.Int(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.SalesOrderSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.SalesOrders", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.SerialMasters",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        SysNumber = c.Int(nullable: false),
                        ItemCode = c.String(),
                        ItemName = c.String(),
                        DistNumber = c.String(),
                        MnfSerial = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantOut = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        Email = c.String(),
                        Contact = c.String(),
                        Branch = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.VatGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VatCode = c.String(),
                        VatName = c.String(),
                        Inactive = c.Boolean(nullable: false),
                        Category = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        WhsCode = c.String(nullable: false, maxLength: 128),
                        WhsName = c.String(nullable: false),
                        Branch = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WhsCode);
            
            CreateTable(
                "dbo.WarrantyRepairLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        LineNum = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        Account = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.WarrantyRepairs", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.WarrantyRepairs",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        UserSign = c.String(),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.WarrantyRepairSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.WarrantyRepairs", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.WarrantyReturnLines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        LineNum = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        Dscription = c.String(nullable: false),
                        UOM = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhsCode = c.String(),
                        Project = c.String(),
                        OcrCode = c.String(),
                        Account = c.String(),
                        ManSerNum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.WarrantyReturns", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.WarrantyReturns",
                c => new
                    {
                        DocEntry = c.Int(nullable: false, identity: true),
                        DocNum = c.Int(nullable: false),
                        CardCode = c.String(nullable: false),
                        CardName = c.String(nullable: false),
                        DocDate = c.DateTime(nullable: false),
                        TaxDate = c.DateTime(nullable: false),
                        NumAtCard = c.String(),
                        Remarks = c.String(),
                        UserSign = c.String(),
                        DocTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        U_SAPStatus = c.Boolean(nullable: false),
                        U_SAPDocEntry = c.Int(nullable: false),
                        U_ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.DocEntry);
            
            CreateTable(
                "dbo.WarrantyReturnSNs",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        DocEntry = c.Int(nullable: false),
                        DocLine = c.Int(),
                        ItemCode = c.String(),
                        MnfSerialNo = c.String(),
                        SerialNo = c.String(),
                        EngineNo = c.String(),
                        ChasisNo = c.String(),
                        Color = c.String(),
                        FrameNo = c.String(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.WarrantyReturns", t => t.DocEntry, cascadeDelete: true)
                .Index(t => t.DocEntry);
            
            CreateTable(
                "dbo.WithHoldings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WTCode = c.String(),
                        WTName = c.String(),
                        InActive = c.Boolean(nullable: false),
                        Category = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseAmnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OffclCode = c.String(),
                        Account = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarrantyReturnSNs", "DocEntry", "dbo.WarrantyReturns");
            DropForeignKey("dbo.WarrantyReturnLines", "DocEntry", "dbo.WarrantyReturns");
            DropForeignKey("dbo.WarrantyRepairSNs", "DocEntry", "dbo.WarrantyRepairs");
            DropForeignKey("dbo.WarrantyRepairLines", "DocEntry", "dbo.WarrantyRepairs");
            DropForeignKey("dbo.SalesOrderSNs", "DocEntry", "dbo.SalesOrders");
            DropForeignKey("dbo.SalesOrderLines", "DocEntry", "dbo.SalesOrders");
            DropForeignKey("dbo.SalesInvoiceWTaxes", "DocEntry", "dbo.SalesInvoices");
            DropForeignKey("dbo.SalesInvoiceSNs", "DocEntry", "dbo.SalesInvoices");
            DropForeignKey("dbo.SalesInvoicePLs", "DocEntry", "dbo.SalesInvoices");
            DropForeignKey("dbo.SalesInvoiceLines", "DocEntry", "dbo.SalesInvoices");
            DropForeignKey("dbo.SalesInvoiceInsts", "DocEntry", "dbo.SalesInvoices");
            DropForeignKey("dbo.ReplacementSNs", "DocEntry", "dbo.Replacements");
            DropForeignKey("dbo.ReplacementLines", "DocEntry", "dbo.Replacements");
            DropForeignKey("dbo.PriceListLines", "PriceListID", "dbo.PriceLists");
            DropForeignKey("dbo.PriceListBranches", "PriceListID", "dbo.PriceLists");
            DropForeignKey("dbo.PaymentTermLines", "ID", "dbo.PaymentTerms");
            DropForeignKey("dbo.OtherGoodsReceiptSNs", "DocEntry", "dbo.OtherGoodsReceipts");
            DropForeignKey("dbo.OtherGoodsReceiptLines", "DocEntry", "dbo.OtherGoodsReceipts");
            DropForeignKey("dbo.OtherGoodsIssueSNs", "DocEntry", "dbo.OtherGoodsIssues");
            DropForeignKey("dbo.OtherGoodsIssueLines", "DocEntry", "dbo.OtherGoodsIssues");
            DropForeignKey("dbo.InvTransferSNs", "DocEntry", "dbo.InvTransfers");
            DropForeignKey("dbo.InvTransferLines", "DocEntry", "dbo.InvTransfers");
            DropForeignKey("dbo.Inventories", "ItemCode", "dbo.Items");
            DropForeignKey("dbo.IncomingLines", "DocEntry", "dbo.Incomings");
            DropForeignKey("dbo.IncomingChecks", "DocEntry", "dbo.Incomings");
            DropForeignKey("dbo.IncomingCards", "DocEntry", "dbo.Incomings");
            DropForeignKey("dbo.GoodsReceiptSNs", "DocEntry", "dbo.GoodsReceipts");
            DropForeignKey("dbo.GoodsReceiptLines", "DocEntry", "dbo.GoodsReceipts");
            DropForeignKey("dbo.GoodsIssueSNs", "DocEntry", "dbo.GoodsIssues");
            DropForeignKey("dbo.GoodsIssueLines", "DocEntry", "dbo.GoodsIssues");
            DropForeignKey("dbo.DPInvoiceLines", "DocEntry", "dbo.DPInvoices");
            DropForeignKey("dbo.CreditMemoLines", "DocEntry", "dbo.CreditMemoes");
            DropForeignKey("dbo.ChangeUnitSNs", "DocEntry", "dbo.ChangeUnits");
            DropForeignKey("dbo.ChangeUnitLines", "DocEntry", "dbo.ChangeUnits");
            DropForeignKey("dbo.CashInvoiceWtaxes", "DocEntry", "dbo.CashInvoices");
            DropForeignKey("dbo.CashInvoiceSNs", "DocEntry", "dbo.CashInvoices");
            DropForeignKey("dbo.CashInvoiceLines", "DocEntry", "dbo.CashInvoices");
            DropForeignKey("dbo.BranchReceivingSNs", "DocEntry", "dbo.BranchReceivings");
            DropForeignKey("dbo.BranchReceivingLines", "DocEntry", "dbo.BranchReceivings");
            DropForeignKey("dbo.BPWithHoldings", "CardCode", "dbo.BusinessPartners");
            DropForeignKey("dbo.Comakers", "CardCode", "dbo.BusinessPartners");
            DropForeignKey("dbo.AccomInvoiceWTaxes", "DocEntry", "dbo.AccomInvoices");
            DropForeignKey("dbo.AccomInvoiceSNs", "DocEntry", "dbo.AccomInvoices");
            DropForeignKey("dbo.AccomInvoiceLines", "DocEntry", "dbo.AccomInvoices");
            DropForeignKey("dbo.AccomInvoiceInsts", "DocEntry", "dbo.AccomInvoices");
            DropIndex("dbo.WarrantyReturnSNs", new[] { "DocEntry" });
            DropIndex("dbo.WarrantyReturnLines", new[] { "DocEntry" });
            DropIndex("dbo.WarrantyRepairSNs", new[] { "DocEntry" });
            DropIndex("dbo.WarrantyRepairLines", new[] { "DocEntry" });
            DropIndex("dbo.SalesOrderSNs", new[] { "DocEntry" });
            DropIndex("dbo.SalesOrderLines", new[] { "DocEntry" });
            DropIndex("dbo.SalesInvoiceWTaxes", new[] { "DocEntry" });
            DropIndex("dbo.SalesInvoiceSNs", new[] { "DocEntry" });
            DropIndex("dbo.SalesInvoicePLs", new[] { "DocEntry" });
            DropIndex("dbo.SalesInvoiceLines", new[] { "DocEntry" });
            DropIndex("dbo.SalesInvoiceInsts", new[] { "DocEntry" });
            DropIndex("dbo.ReplacementSNs", new[] { "DocEntry" });
            DropIndex("dbo.ReplacementLines", new[] { "DocEntry" });
            DropIndex("dbo.PriceListLines", new[] { "PriceListID" });
            DropIndex("dbo.PriceListBranches", new[] { "PriceListID" });
            DropIndex("dbo.PaymentTermLines", new[] { "ID" });
            DropIndex("dbo.OtherGoodsReceiptSNs", new[] { "DocEntry" });
            DropIndex("dbo.OtherGoodsReceiptLines", new[] { "DocEntry" });
            DropIndex("dbo.OtherGoodsIssueSNs", new[] { "DocEntry" });
            DropIndex("dbo.OtherGoodsIssueLines", new[] { "DocEntry" });
            DropIndex("dbo.InvTransferSNs", new[] { "DocEntry" });
            DropIndex("dbo.InvTransferLines", new[] { "DocEntry" });
            DropIndex("dbo.Inventories", new[] { "ItemCode" });
            DropIndex("dbo.IncomingLines", new[] { "DocEntry" });
            DropIndex("dbo.IncomingChecks", new[] { "DocEntry" });
            DropIndex("dbo.IncomingCards", new[] { "DocEntry" });
            DropIndex("dbo.GoodsReceiptSNs", new[] { "DocEntry" });
            DropIndex("dbo.GoodsReceiptLines", new[] { "DocEntry" });
            DropIndex("dbo.GoodsIssueSNs", new[] { "DocEntry" });
            DropIndex("dbo.GoodsIssueLines", new[] { "DocEntry" });
            DropIndex("dbo.DPInvoiceLines", new[] { "DocEntry" });
            DropIndex("dbo.CreditMemoLines", new[] { "DocEntry" });
            DropIndex("dbo.ChangeUnitSNs", new[] { "DocEntry" });
            DropIndex("dbo.ChangeUnitLines", new[] { "DocEntry" });
            DropIndex("dbo.CashInvoiceWtaxes", new[] { "DocEntry" });
            DropIndex("dbo.CashInvoiceSNs", new[] { "DocEntry" });
            DropIndex("dbo.CashInvoiceLines", new[] { "DocEntry" });
            DropIndex("dbo.BranchReceivingSNs", new[] { "DocEntry" });
            DropIndex("dbo.BranchReceivingLines", new[] { "DocEntry" });
            DropIndex("dbo.Comakers", new[] { "CardCode" });
            DropIndex("dbo.BPWithHoldings", new[] { "CardCode" });
            DropIndex("dbo.AccomInvoiceWTaxes", new[] { "DocEntry" });
            DropIndex("dbo.AccomInvoiceSNs", new[] { "DocEntry" });
            DropIndex("dbo.AccomInvoiceLines", new[] { "DocEntry" });
            DropIndex("dbo.AccomInvoiceInsts", new[] { "DocEntry" });
            DropTable("dbo.WithHoldings");
            DropTable("dbo.WarrantyReturnSNs");
            DropTable("dbo.WarrantyReturns");
            DropTable("dbo.WarrantyReturnLines");
            DropTable("dbo.WarrantyRepairSNs");
            DropTable("dbo.WarrantyRepairs");
            DropTable("dbo.WarrantyRepairLines");
            DropTable("dbo.Warehouses");
            DropTable("dbo.VatGroups");
            DropTable("dbo.Users");
            DropTable("dbo.SerialMasters");
            DropTable("dbo.SalesOrderSNs");
            DropTable("dbo.SalesOrders");
            DropTable("dbo.SalesOrderLines");
            DropTable("dbo.SalesInvoiceWTaxes");
            DropTable("dbo.SalesInvoiceSNs");
            DropTable("dbo.SalesInvoicePLs");
            DropTable("dbo.SalesInvoiceLines");
            DropTable("dbo.SalesInvoices");
            DropTable("dbo.SalesInvoiceInsts");
            DropTable("dbo.SalesEmployees");
            DropTable("dbo.ReplacementSNs");
            DropTable("dbo.Replacements");
            DropTable("dbo.ReplacementLines");
            DropTable("dbo.Projects");
            DropTable("dbo.PriceListLines");
            DropTable("dbo.PriceLists");
            DropTable("dbo.PriceListBranches");
            DropTable("dbo.PaymentTermLines");
            DropTable("dbo.PaymentTerms");
            DropTable("dbo.OtherGoodsReceiptSNs");
            DropTable("dbo.OtherGoodsReceipts");
            DropTable("dbo.OtherGoodsReceiptLines");
            DropTable("dbo.OtherGoodsIssueSNs");
            DropTable("dbo.OtherGoodsIssues");
            DropTable("dbo.OtherGoodsIssueLines");
            DropTable("dbo.Numberings");
            DropTable("dbo.NumberingLines");
            DropTable("dbo.ItemGroups");
            DropTable("dbo.InvTransferSNs");
            DropTable("dbo.InvTransfers");
            DropTable("dbo.InvTransferLines");
            DropTable("dbo.Items");
            DropTable("dbo.Inventories");
            DropTable("dbo.IncomingLines");
            DropTable("dbo.IncomingChecks");
            DropTable("dbo.Incomings");
            DropTable("dbo.IncomingCards");
            DropTable("dbo.GoodsReceiptSNs");
            DropTable("dbo.GoodsReceipts");
            DropTable("dbo.GoodsReceiptLines");
            DropTable("dbo.GoodsIssueSNs");
            DropTable("dbo.GoodsIssues");
            DropTable("dbo.GoodsIssueLines");
            DropTable("dbo.GLAccounts");
            DropTable("dbo.EmployeeMasters");
            DropTable("dbo.DPInvoices");
            DropTable("dbo.DPInvoiceLines");
            DropTable("dbo.CreditMemoLines");
            DropTable("dbo.CreditMemoes");
            DropTable("dbo.CreditCards");
            DropTable("dbo.CostCenters");
            DropTable("dbo.ChangeUnitSNs");
            DropTable("dbo.ChangeUnits");
            DropTable("dbo.ChangeUnitLines");
            DropTable("dbo.CashInvoiceWtaxes");
            DropTable("dbo.CashInvoiceSNs");
            DropTable("dbo.CashInvoices");
            DropTable("dbo.CashInvoiceLines");
            DropTable("dbo.BranchReceivingSNs");
            DropTable("dbo.BranchReceivings");
            DropTable("dbo.BranchReceivingLines");
            DropTable("dbo.Comakers");
            DropTable("dbo.BusinessPartners");
            DropTable("dbo.BPWithHoldings");
            DropTable("dbo.Banks");
            DropTable("dbo.AccomInvoiceWTaxes");
            DropTable("dbo.AccomInvoiceSNs");
            DropTable("dbo.AccomInvoiceLines");
            DropTable("dbo.AccomInvoices");
            DropTable("dbo.AccomInvoiceInsts");
        }
    }
}
