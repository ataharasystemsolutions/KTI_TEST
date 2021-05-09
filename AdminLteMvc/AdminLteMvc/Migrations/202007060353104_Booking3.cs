namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "trnStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "trnStatus");
        }
    }
}
