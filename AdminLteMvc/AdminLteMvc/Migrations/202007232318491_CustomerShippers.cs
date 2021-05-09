namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerShippers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerShippers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        custShipr = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerShippers");
        }
    }
}
