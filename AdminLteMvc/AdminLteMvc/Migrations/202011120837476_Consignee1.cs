namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Consignee1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consignees", "consigneeaddress", c => c.String());
            AddColumn("dbo.Consignees", "consigneecontactno", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consignees", "consigneecontactno");
            DropColumn("dbo.Consignees", "consigneeaddress");
        }
    }
}
