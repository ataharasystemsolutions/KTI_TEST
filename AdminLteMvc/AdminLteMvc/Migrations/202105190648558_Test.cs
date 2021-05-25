namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EIRIns", "vesselID", c => c.Int(nullable: false));
            AddColumn("dbo.EIRIns", "voyageID", c => c.Int(nullable: false));
            AddColumn("dbo.EirPullOuts", "vesselID", c => c.Int(nullable: false));
            AddColumn("dbo.EirPullOuts", "voyageID", c => c.Int(nullable: false));
            AddColumn("dbo.FinalBillings", "voyageID", c => c.Int(nullable: false));
            AddColumn("dbo.ProformaBills", "proformaBillVesselID", c => c.Int(nullable: false));
            AddColumn("dbo.ProformaBills", "proformaBillVoyageID", c => c.Int(nullable: false));
            AddColumn("dbo.VoyageNoes", "status", c => c.String());
            AddColumn("dbo.VoyageNoes", "transactionNumber", c => c.String());
            AddColumn("dbo.VoyageNoCategories", "portOrigin", c => c.String());
            AddColumn("dbo.VoyageNoCategories", "portDestination", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VoyageNoCategories", "portDestination");
            DropColumn("dbo.VoyageNoCategories", "portOrigin");
            DropColumn("dbo.VoyageNoes", "transactionNumber");
            DropColumn("dbo.VoyageNoes", "status");
            DropColumn("dbo.ProformaBills", "proformaBillVoyageID");
            DropColumn("dbo.ProformaBills", "proformaBillVesselID");
            DropColumn("dbo.FinalBillings", "voyageID");
            DropColumn("dbo.EirPullOuts", "voyageID");
            DropColumn("dbo.EirPullOuts", "vesselID");
            DropColumn("dbo.EIRIns", "voyageID");
            DropColumn("dbo.EIRIns", "vesselID");
        }
    }
}
