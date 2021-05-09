namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConVanStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConVanSizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        sizes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ConVanStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConVanStatus");
            DropTable("dbo.ConVanSizes");
        }
    }
}
