namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        bookingtype = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookingTypes");
        }
    }
}
