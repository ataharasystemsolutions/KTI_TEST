namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "quantity", c => c.String());
            AddColumn("dbo.TransactionDetails", "unitofmeasurement", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "unitofmeasurement");
            DropColumn("dbo.TransactionDetails", "quantity");
        }
    }
}
