namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SealStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SealStatus",
                c => new
                    {
                        sealID = c.Int(nullable: false, identity: true),
                        sealstatus = c.String(),
                    })
                .PrimaryKey(t => t.sealID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SealStatus");
        }
    }
}
