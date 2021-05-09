namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "docNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "docNumber");
        }
    }
}
