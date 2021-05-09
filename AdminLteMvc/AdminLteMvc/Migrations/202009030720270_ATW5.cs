namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATW5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ATWs", "atwStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ATWs", "atwStatus");
        }
    }
}
