namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATW7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ATWs", "transactionno1", c => c.String());
            AddColumn("dbo.ATWs", "transactionno2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ATWs", "transactionno2");
            DropColumn("dbo.ATWs", "transactionno1");
        }
    }
}
