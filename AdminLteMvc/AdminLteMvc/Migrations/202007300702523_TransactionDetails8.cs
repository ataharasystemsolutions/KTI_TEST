namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "chargeTo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "chargeTo");
        }
    }
}
