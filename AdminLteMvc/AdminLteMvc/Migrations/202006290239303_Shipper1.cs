namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shipper1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        shipperID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.shipperID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shippers");
        }
    }
}
