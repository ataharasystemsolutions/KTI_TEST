namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mnemonics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mnemonics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        mnemonic = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mnemonics");
        }
    }
}
