namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProformaBills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProformaBills",
                c => new
                    {
                        proformaBillID = c.Int(nullable: false, identity: true),
                        proformaBillDate = c.String(),
                        proformaBillVesselName = c.String(),
                        proformaBillVoyageNo = c.String(),
                        proformaBillDestination = c.String(),
                        proformaBillShipper = c.String(),
                        proformaBillShippersAddress = c.String(),
                        proformaBillShippersTelNo = c.String(),
                        proformaBillServiceType = c.String(),
                        proformaBillConsignee = c.String(),
                        proformaBillConsigneesAddress = c.String(),
                        proformaBillConsigneesTelNo = c.String(),
                        proformaBillNo = c.String(),
                        proformaBillMarks = c.String(),
                        proformaBillQty = c.String(),
                        proformaBillUnit = c.String(),
                        proformaBillDescriptionOfCargo = c.String(),
                        proformaBillValue = c.String(),
                        proformaBillWeight = c.String(),
                        proformaBillMeasurement = c.String(),
                        proformaBillRemarks = c.String(),
                        proformaBillMeasuredBy = c.String(),
                        proformaBillTruckersName = c.String(),
                        proformaBillShippersName = c.String(),
                    })
                .PrimaryKey(t => t.proformaBillID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProformaBills");
        }
    }
}
