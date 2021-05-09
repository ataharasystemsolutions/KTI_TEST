namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PortOfOrigin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PortOfDestinations",
                c => new
                    {
                        podID = c.Int(nullable: false, identity: true),
                        destinationport = c.String(),
                    })
                .PrimaryKey(t => t.podID);
            
            CreateTable(
                "dbo.PortOfOrigins",
                c => new
                    {
                        poiID = c.Int(nullable: false, identity: true),
                        originport = c.String(),
                    })
                .PrimaryKey(t => t.poiID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PortOfOrigins");
            DropTable("dbo.PortOfDestinations");
        }
    }
}
