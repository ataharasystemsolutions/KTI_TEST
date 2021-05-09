namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TransactionDetails", "documentID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TransactionDetails", "documentID", c => c.Int(nullable: false));
        }
    }
}
