namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "booktype", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "booktype");
        }
    }
}
