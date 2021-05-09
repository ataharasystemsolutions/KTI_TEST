namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vessel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vessels", "vesselMnemonic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vessels", "vesselMnemonic");
        }
    }
}
