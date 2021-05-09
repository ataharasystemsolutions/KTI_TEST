namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentMode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentModes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        paymentmode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentModes");
        }
    }
}
