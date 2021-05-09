namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EIRIn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EIRIns",
                c => new
                    {
                        EIRIID = c.Int(nullable: false, identity: true),
                        EIRINo = c.String(),
                        EIRIReferenceNo = c.String(),
                        EIRIDate = c.String(),
                        EIRITime = c.String(),
                        EIRIServiceType = c.String(),
                        EIRIConvanStatus = c.String(),
                        EIRITransactionNo = c.String(),
                        EIRIVessel = c.String(),
                        EIRIVoyageNo = c.String(),
                        EIRIPortOfOrigin = c.String(),
                        EIRIRelayPort = c.String(),
                        EIRIPortOfDestination = c.String(),
                        EIRIConvanNo = c.String(),
                        EIRISealNo = c.String(),
                        EIRISealStatus = c.String(),
                        EIRIConvanSize = c.String(),
                        EIRIWeight = c.String(),
                        EIRIVolume = c.String(),
                        EIRIShipper = c.String(),
                        EIRIConsignee = c.String(),
                        EIRITrucker = c.String(),
                        EIRIPlateNo = c.String(),
                        EIRIDriversName = c.String(),
                        EIRIDamagesCode = c.String(),
                        EIRISCR = c.String(),
                        EIRIStatus = c.String(),
                    })
                .PrimaryKey(t => t.EIRIID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EIRIns");
        }
    }
}
