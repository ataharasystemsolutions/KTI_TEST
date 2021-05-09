namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "consignee6", c => c.String());
            AddColumn("dbo.TransactionDetails", "consignee7", c => c.String());
            AddColumn("dbo.TransactionDetails", "consignee8", c => c.String());
            AddColumn("dbo.TransactionDetails", "consignee9", c => c.String());
            AddColumn("dbo.TransactionDetails", "consignee10", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneeAdd6", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneeAdd7", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneeAdd8", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneeAdd9", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneeAdd10", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneetelno6", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneetelno7", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneetelno8", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneetelno9", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneetelno10", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "consigneetelno10");
            DropColumn("dbo.TransactionDetails", "consigneetelno9");
            DropColumn("dbo.TransactionDetails", "consigneetelno8");
            DropColumn("dbo.TransactionDetails", "consigneetelno7");
            DropColumn("dbo.TransactionDetails", "consigneetelno6");
            DropColumn("dbo.TransactionDetails", "consigneeAdd10");
            DropColumn("dbo.TransactionDetails", "consigneeAdd9");
            DropColumn("dbo.TransactionDetails", "consigneeAdd8");
            DropColumn("dbo.TransactionDetails", "consigneeAdd7");
            DropColumn("dbo.TransactionDetails", "consigneeAdd6");
            DropColumn("dbo.TransactionDetails", "consignee10");
            DropColumn("dbo.TransactionDetails", "consignee9");
            DropColumn("dbo.TransactionDetails", "consignee8");
            DropColumn("dbo.TransactionDetails", "consignee7");
            DropColumn("dbo.TransactionDetails", "consignee6");
        }
    }
}
