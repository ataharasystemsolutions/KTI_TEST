namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Truckers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Truckers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        truckername = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Truckers");
        }
    }
}
