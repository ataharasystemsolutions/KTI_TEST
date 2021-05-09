namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "serviceType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "serviceType");
        }
    }
}
