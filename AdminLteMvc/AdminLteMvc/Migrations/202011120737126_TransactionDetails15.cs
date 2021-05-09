namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "consize", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "consize");
        }
    }
}
