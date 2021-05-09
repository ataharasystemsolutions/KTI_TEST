namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "preparedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "preparedBy");
        }
    }
}
