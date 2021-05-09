namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "cnameshipper", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "cnameshipper");
        }
    }
}
