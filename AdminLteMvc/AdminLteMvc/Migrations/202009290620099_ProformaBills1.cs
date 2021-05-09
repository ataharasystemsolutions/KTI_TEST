namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProformaBills1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProformaBills", "proformaBillRefNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProformaBills", "proformaBillRefNo");
        }
    }
}
