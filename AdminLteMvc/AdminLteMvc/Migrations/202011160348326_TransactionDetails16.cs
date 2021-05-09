namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "chargee", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "chargee");
        }
    }
}
