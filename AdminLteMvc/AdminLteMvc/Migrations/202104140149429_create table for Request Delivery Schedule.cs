namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtableforRequestDeliverySchedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestDeliverySchedules",
                c => new
                    {
                        deliveryID = c.Int(nullable: false, identity: true),
                        dateCreated = c.DateTime(),
                        userID = c.Int(nullable: false),
                        shipper = c.String(),
                        serviceType = c.String(),
                        convanNo = c.String(),
                        EIRONo = c.String(),
                        EIROTransactionNoget = c.String(),
                        latdateChanged = c.DateTime(),
                        lastuserID = c.Int(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.deliveryID);
            
            CreateTable(
                "dbo.RequestDeliveryScheduleConsignees",
                c => new
                    {
                        consigneeId = c.Int(nullable: false, identity: true),
                        deliveryID = c.Int(nullable: false),
                        consigneeName = c.String(),
                        consigneeAddress = c.String(),
                        consigneeContact = c.String(),
                        startDate = c.DateTime(),
                        endDate = c.DateTime(),
                        Action = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.consigneeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RequestDeliveryScheduleConsignees");
            DropTable("dbo.RequestDeliverySchedules");
        }
    }
}
