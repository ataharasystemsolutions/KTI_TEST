namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATW1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ATWs", "atwYear", c => c.String());
            AddColumn("dbo.ATWs", "atwBkID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ATWs", "atwBkID");
            DropColumn("dbo.ATWs", "atwYear");
        }
    }
}
