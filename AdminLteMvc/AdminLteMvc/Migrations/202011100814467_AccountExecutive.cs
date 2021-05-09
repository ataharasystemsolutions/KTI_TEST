namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountExecutive : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountExecutives",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        executivename = c.String(),
                        contactnumber = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountExecutives");
        }
    }
}
