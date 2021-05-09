namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "documentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "documentID");
        }
    }
}
