namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "docDate", c => c.String());
            AddColumn("dbo.Bookings", "docNum", c => c.String());
            AddColumn("dbo.Bookings", "billTo", c => c.String());
            AddColumn("dbo.Bookings", "mnemonic", c => c.String());
            AddColumn("dbo.Bookings", "cnameshpr", c => c.String());
            AddColumn("dbo.Bookings", "csize", c => c.String());
            AddColumn("dbo.Bookings", "cstatus", c => c.String());
            AddColumn("dbo.Bookings", "cargoType", c => c.String());
            AddColumn("dbo.Bookings", "conClass", c => c.String());
            AddColumn("dbo.Bookings", "conRqrmnts", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "conRqrmnts");
            DropColumn("dbo.Bookings", "conClass");
            DropColumn("dbo.Bookings", "cargoType");
            DropColumn("dbo.Bookings", "cstatus");
            DropColumn("dbo.Bookings", "csize");
            DropColumn("dbo.Bookings", "cnameshpr");
            DropColumn("dbo.Bookings", "mnemonic");
            DropColumn("dbo.Bookings", "billTo");
            DropColumn("dbo.Bookings", "docNum");
            DropColumn("dbo.Bookings", "docDate");
        }
    }
}
