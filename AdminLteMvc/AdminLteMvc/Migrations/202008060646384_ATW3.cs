namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATW3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ATWs", "consignee");
            DropColumn("dbo.ATWs", "cargo");
            DropColumn("dbo.ATWs", "serviceMode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ATWs", "serviceMode", c => c.String());
            AddColumn("dbo.ATWs", "cargo", c => c.String());
            AddColumn("dbo.ATWs", "consignee", c => c.String());
        }
    }
}
