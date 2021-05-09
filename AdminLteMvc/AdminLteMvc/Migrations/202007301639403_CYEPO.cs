namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYEPO : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CYEPOes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        cyEpo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CYLDs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        cyLd = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CYSAs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        cySa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CYSAs");
            DropTable("dbo.CYLDs");
            DropTable("dbo.CYEPOes");
        }
    }
}
