namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvoyageLegTBLEfinalBillings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinalBillings", "voyageLeg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinalBillings", "voyageLeg");
        }
    }
}
