namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EirPullOut : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EirPullOuts",
                c => new
                    {
                        EIROID = c.Int(nullable: false, identity: true),
                        EIRONo = c.String(),
                        EIRODate = c.String(),
                        EIROTime = c.String(),
                        EIROServiceType = c.String(),
                        EIROConvanStatus = c.String(),
                        EIROTransactionNo = c.String(),
                        EIROVessel = c.String(),
                        EIROVoyageNo = c.String(),
                        EIROPortOfOrigin = c.String(),
                        EIRORelayPort = c.String(),
                        EIROPortOfDestination = c.String(),
                        EIROConvanNo = c.String(),
                        EIROSealNo = c.String(),
                        EIROSealStatus = c.String(),
                        EIROConvanSize = c.String(),
                        EIROWeight = c.String(),
                        EIROVolume = c.String(),
                        EIROShipper = c.String(),
                        EIROConsignee = c.String(),
                        EIROTrucker = c.String(),
                        EIROPlateNo = c.String(),
                        EIRODriversName = c.String(),
                        EIRODamagesCode = c.String(),
                        EIROSCR = c.String(),
                    })
                .PrimaryKey(t => t.EIROID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EirPullOuts");
        }
    }
}
