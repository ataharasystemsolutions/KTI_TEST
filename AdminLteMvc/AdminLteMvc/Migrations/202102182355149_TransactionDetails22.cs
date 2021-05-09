namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "convanno", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "convanno");
        }
    }
}
