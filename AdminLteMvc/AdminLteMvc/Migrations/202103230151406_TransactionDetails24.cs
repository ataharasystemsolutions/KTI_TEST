namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails24 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TransactionDetails", "priceList");
            DropColumn("dbo.TransactionDetails", "consignee");
            DropColumn("dbo.TransactionDetails", "consigneeAdd");
            DropColumn("dbo.TransactionDetails", "consigneetelno");
            DropColumn("dbo.TransactionDetails", "cargoType");
            DropColumn("dbo.TransactionDetails", "unitofmeasurement");
            DropColumn("dbo.TransactionDetails", "chargeTo");
            DropColumn("dbo.TransactionDetails", "trnInputtedDate");
            DropColumn("dbo.TransactionDetails", "price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionDetails", "price", c => c.String());
            AddColumn("dbo.TransactionDetails", "trnInputtedDate", c => c.String());
            AddColumn("dbo.TransactionDetails", "chargeTo", c => c.String());
            AddColumn("dbo.TransactionDetails", "unitofmeasurement", c => c.String());
            AddColumn("dbo.TransactionDetails", "cargoType", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneetelno", c => c.String());
            AddColumn("dbo.TransactionDetails", "consigneeAdd", c => c.String());
            AddColumn("dbo.TransactionDetails", "consignee", c => c.String());
            AddColumn("dbo.TransactionDetails", "priceList", c => c.String());
        }
    }
}
