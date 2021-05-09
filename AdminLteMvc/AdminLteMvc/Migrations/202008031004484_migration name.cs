namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "transactionDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "transactionDate");
        }
    }
}
