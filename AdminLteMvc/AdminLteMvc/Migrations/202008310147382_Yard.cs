namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Yard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yards",
                c => new
                    {
                        yardID = c.Int(nullable: false, identity: true),
                        yardATWBkNo = c.String(),
                        yardTrnNo = c.String(),
                        yardConVanNo = c.String(),
                        yardAssignedBy = c.String(),
                    })
                .PrimaryKey(t => t.yardID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Yards");
        }
    }
}
