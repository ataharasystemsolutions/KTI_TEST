namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails21 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TransactionDetails", "convanno");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionDetails", "convanno", c => c.String());
        }
    }
}
