namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mnemonics2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mnemonics", "customershippername", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mnemonics", "customershippername");
        }
    }
}
