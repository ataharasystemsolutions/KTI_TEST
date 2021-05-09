namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CSRs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        csrname = c.String(),
                        contactnumber = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Bookings", "inputtedby", c => c.String());
            AddColumn("dbo.Bookings", "csr", c => c.String());
            AddColumn("dbo.Bookings", "accountexecutive", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "accountexecutive");
            DropColumn("dbo.Bookings", "csr");
            DropColumn("dbo.Bookings", "inputtedby");
            DropTable("dbo.CSRs");
        }
    }
}
