namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "price", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "price");
        }
    }
}
