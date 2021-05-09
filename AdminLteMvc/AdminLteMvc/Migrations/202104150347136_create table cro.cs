namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtablecro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CROes",
                c => new
                    {
                        croID = c.Int(nullable: false, identity: true),
                        deliveryId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        dateCreated = c.DateTime(),
                        shipper = c.String(),
                        shipperContactPerson = c.String(),
                        consignee = c.String(),
                        transactionNo = c.String(),
                        EIRONO = c.String(),
                        expyreDate = c.DateTime(),
                        AuthorizedTruckerDestination = c.String(),
                        AuthorizedDriverDestination = c.String(),
                        AuthorizedTruckPlateNoDestination = c.String(),
                        CYPullofOutofCargoLadenConVan = c.String(),
                        CYStuffingStripping = c.String(),
                        PackedAs = c.String(),
                        ConVanFlatRackNo = c.String(),
                        Quantity = c.String(),
                        Unit = c.String(),
                        CargoDesciption = c.String(),
                        OtherCargoDetails = c.String(),
                        ServiceMode = c.String(),
                        Origin = c.String(),
                        Destination = c.String(),
                        VesselVoyage = c.String(),
                        SpecialHandlingRequirement = c.String(),
                        Remarks = c.String(),
                        IssuedBy = c.String(),
                        ApprovedBy = c.String(),
                        lastUserId = c.Int(nullable: false),
                        datelastChange = c.DateTime(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.croID);
            
        }
        public override void Down()
        {
            DropTable("dbo.CROes");
        }
    }
}
