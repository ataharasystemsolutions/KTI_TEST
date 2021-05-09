namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InputtedBy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InputtedBies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        contactnumber = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InputtedBies");
        }
    }
}
