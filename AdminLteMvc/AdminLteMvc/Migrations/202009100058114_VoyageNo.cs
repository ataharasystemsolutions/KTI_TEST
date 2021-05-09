namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoyageNo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VoyageNoes",
                c => new
                    {
                        voyageID = c.Int(nullable: false, identity: true),
                        voyageNo = c.String(),
                        vesselid = c.String(),
                    })
                .PrimaryKey(t => t.voyageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VoyageNoes");
        }
    }
}
