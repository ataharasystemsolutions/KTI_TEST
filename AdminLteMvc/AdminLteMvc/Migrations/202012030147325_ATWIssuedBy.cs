namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATWIssuedBy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ATWIssuedBies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        issuersname = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ATWIssuedBies");
        }
    }
}
