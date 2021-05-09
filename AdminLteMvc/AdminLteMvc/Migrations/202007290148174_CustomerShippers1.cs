namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerShippers1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerShippers", "mnemID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerShippers", "mnemID");
        }
    }
}
