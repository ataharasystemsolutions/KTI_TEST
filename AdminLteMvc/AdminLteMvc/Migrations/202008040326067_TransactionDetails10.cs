namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "trnInputtedDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "trnInputtedDate");
        }
    }
}
