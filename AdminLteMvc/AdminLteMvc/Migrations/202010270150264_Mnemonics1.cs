namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mnemonics1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mnemonics", "shipperstelephoneno", c => c.String());
            AddColumn("dbo.Mnemonics", "address1", c => c.String());
            AddColumn("dbo.Mnemonics", "address2", c => c.String());
            AddColumn("dbo.Mnemonics", "address3", c => c.String());
            AddColumn("dbo.Mnemonics", "address4", c => c.String());
            AddColumn("dbo.Mnemonics", "address5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mnemonics", "address5");
            DropColumn("dbo.Mnemonics", "address4");
            DropColumn("dbo.Mnemonics", "address3");
            DropColumn("dbo.Mnemonics", "address2");
            DropColumn("dbo.Mnemonics", "address1");
            DropColumn("dbo.Mnemonics", "shipperstelephoneno");
        }
    }
}
