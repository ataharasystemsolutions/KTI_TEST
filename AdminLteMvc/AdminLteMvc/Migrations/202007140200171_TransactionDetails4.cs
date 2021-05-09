namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "dtlStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "dtlStatus");
        }
    }
}
