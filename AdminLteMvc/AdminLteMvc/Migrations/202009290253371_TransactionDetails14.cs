namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "consigneetelno", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "consigneetelno");
        }
    }
}
