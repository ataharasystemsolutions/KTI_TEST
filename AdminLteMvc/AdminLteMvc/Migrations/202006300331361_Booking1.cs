namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "remarks");
        }
    }
}
