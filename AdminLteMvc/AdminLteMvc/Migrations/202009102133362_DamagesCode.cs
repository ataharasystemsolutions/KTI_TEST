namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DamagesCode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DamagesCodes",
                c => new
                    {
                        damageID = c.Int(nullable: false, identity: true),
                        damage = c.String(),
                    })
                .PrimaryKey(t => t.damageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DamagesCodes");
        }
    }
}
