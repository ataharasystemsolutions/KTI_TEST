namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "shipperAddress", c => c.String());
            AddColumn("dbo.Bookings", "shipperTelNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "shipperTelNo");
            DropColumn("dbo.Bookings", "shipperAddress");
        }
    }
}
