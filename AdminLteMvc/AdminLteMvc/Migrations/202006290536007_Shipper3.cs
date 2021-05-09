namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shipper3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "payMode", c => c.String());
            AddColumn("dbo.Bookings", "cyEPO", c => c.String());
            AddColumn("dbo.Bookings", "cySA", c => c.String());
            AddColumn("dbo.Bookings", "cyLD", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "cyLD");
            DropColumn("dbo.Bookings", "cySA");
            DropColumn("dbo.Bookings", "cyEPO");
            DropColumn("dbo.Bookings", "payMode");
        }
    }
}
