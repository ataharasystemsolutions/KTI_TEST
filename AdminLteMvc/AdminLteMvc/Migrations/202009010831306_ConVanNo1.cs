namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConVanNo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConVanNoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        convan = c.String(),
                        convanNo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConVanNoes");
        }
    }
}
