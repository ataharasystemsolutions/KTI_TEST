namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mnemonics3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mnemonics", "contactperson", c => c.String());
            AddColumn("dbo.Mnemonics", "contactno", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mnemonics", "contactno");
            DropColumn("dbo.Mnemonics", "contactperson");
        }
    }
}
