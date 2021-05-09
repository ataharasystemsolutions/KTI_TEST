namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "priceList");
            DropColumn("dbo.Bookings", "origin");
            DropColumn("dbo.Bookings", "destination");
            DropColumn("dbo.Bookings", "consignee");
            DropColumn("dbo.Bookings", "consigneeAdd");
            DropColumn("dbo.Bookings", "cargoType");
            DropColumn("dbo.Bookings", "conClass");
            DropColumn("dbo.Bookings", "conRqrmnts");
            DropColumn("dbo.Bookings", "payMode");
            DropColumn("dbo.Bookings", "cyEPO");
            DropColumn("dbo.Bookings", "cySA");
            DropColumn("dbo.Bookings", "cyLD");
            DropColumn("dbo.Bookings", "remarks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "remarks", c => c.String());
            AddColumn("dbo.Bookings", "cyLD", c => c.String());
            AddColumn("dbo.Bookings", "cySA", c => c.String());
            AddColumn("dbo.Bookings", "cyEPO", c => c.String());
            AddColumn("dbo.Bookings", "payMode", c => c.String());
            AddColumn("dbo.Bookings", "conRqrmnts", c => c.String());
            AddColumn("dbo.Bookings", "conClass", c => c.String());
            AddColumn("dbo.Bookings", "cargoType", c => c.String());
            AddColumn("dbo.Bookings", "consigneeAdd", c => c.String());
            AddColumn("dbo.Bookings", "consignee", c => c.String());
            AddColumn("dbo.Bookings", "destination", c => c.String());
            AddColumn("dbo.Bookings", "origin", c => c.String());
            AddColumn("dbo.Bookings", "priceList", c => c.String());
        }
    }
}
