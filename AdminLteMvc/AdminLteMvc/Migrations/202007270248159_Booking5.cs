namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "docYear", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "docYear");
        }
    }
}
