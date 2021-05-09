namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConVanRequirements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConVanRequirements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        requirements = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConVanRequirements");
        }
    }
}
