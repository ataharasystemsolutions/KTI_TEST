namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATWDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ATWDetails",
                c => new
                    {
                        dtlID = c.Int(nullable: false, identity: true),
                        atwBkID = c.Int(nullable: false),
                        atwbkNo = c.String(),
                        atwDtlStatus = c.String(),
                        trnNo = c.String(),
                        noUnits = c.String(),
                        cSize = c.String(),
                        cStatus = c.String(),
                        origin = c.String(),
                        destination = c.String(),
                    })
                .PrimaryKey(t => t.dtlID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ATWDetails");
        }
    }
}
