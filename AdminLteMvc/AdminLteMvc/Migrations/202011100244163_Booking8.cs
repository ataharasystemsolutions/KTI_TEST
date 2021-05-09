namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "contactperson", c => c.String());
            AddColumn("dbo.Bookings", "contactno", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "contactno");
            DropColumn("dbo.Bookings", "contactperson");
        }
    }
}
