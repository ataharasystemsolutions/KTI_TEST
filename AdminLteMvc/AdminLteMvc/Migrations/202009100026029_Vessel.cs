namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vessel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vessels",
                c => new
                    {
                        vesselID = c.Int(nullable: false, identity: true),
                        vesselName = c.String(),
                    })
                .PrimaryKey(t => t.vesselID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vessels");
        }
    }
}
