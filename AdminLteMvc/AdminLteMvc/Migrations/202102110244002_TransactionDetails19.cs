namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "consignee1", c => c.String());
            AddColumn("dbo.TransactionDetails", "consignee2", c => c.String());
            AddColumn("dbo.TransactionDetails", "consignee3", c => c.String());
            AddColumn("dbo.TransactionDetails", "consignee4", c => c.String());
            AddColumn("dbo.TransactionDetails", "consignee5", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneeAdd1", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneeAdd2", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneeAdd3", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneeAdd4", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneeAdd5", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneetelno1", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneetelno2", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneetelno3", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneetelno4", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneetelno5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "consigneetelno5");
            DropColumn("dbo.TransactionDetails", "consigneetelno4");
            DropColumn("dbo.TransactionDetails", "consigneetelno3");
            DropColumn("dbo.TransactionDetails", "consigneetelno2");
            DropColumn("dbo.TransactionDetails", "consigneetelno1");
            DropColumn("dbo.TransactionDetails", "consigneeAdd5");
            DropColumn("dbo.TransactionDetails", "consigneeAdd4");
            DropColumn("dbo.TransactionDetails", "consigneeAdd3");
            DropColumn("dbo.TransactionDetails", "consigneeAdd2");
            DropColumn("dbo.TransactionDetails", "consigneeAdd1");
            DropColumn("dbo.TransactionDetails", "consignee5");
            DropColumn("dbo.TransactionDetails", "consignee4");
            DropColumn("dbo.TransactionDetails", "consignee3");
            DropColumn("dbo.TransactionDetails", "consignee2");
            DropColumn("dbo.TransactionDetails", "consignee1");
        }
    }
}
