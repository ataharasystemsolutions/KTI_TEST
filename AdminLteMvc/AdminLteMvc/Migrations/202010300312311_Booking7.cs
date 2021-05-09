namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "inhouseBookingDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "inhouseBookingDate");
        }
    }
}
