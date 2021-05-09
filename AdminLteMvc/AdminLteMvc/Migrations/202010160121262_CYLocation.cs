namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYLocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CYLocations",
                c => new
                    {
                        cyID = c.Int(nullable: false, identity: true),
                        cyCode = c.String(),
                        cyLocation = c.String(),
                    })
                .PrimaryKey(t => t.cyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CYLocations");
        }
    }
}
