namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceGroups",
                c => new
                    {
                        pID = c.Int(nullable: false, identity: true),
                        priceGroup = c.String(),
                    })
                .PrimaryKey(t => t.pID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PriceGroups");
        }
    }
}
