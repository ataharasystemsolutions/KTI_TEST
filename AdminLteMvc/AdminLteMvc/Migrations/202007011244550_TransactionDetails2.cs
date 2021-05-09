namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetails2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionDetails",
                c => new
                    {
                        tranID = c.Int(nullable: false, identity: true),
                        transactionNo = c.String(),
                        priceList = c.String(),
                        origin = c.String(),
                        destination = c.String(),
                        consignee = c.String(),
                        consigneeAdd = c.String(),
                        cargoType = c.String(),
                        conClass = c.String(),
                        conRqrmnts = c.String(),
                        payMode = c.String(),
                        cyEPO = c.String(),
                        cySA = c.String(),
                        cyLD = c.String(),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.tranID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransactionDetails");
        }
    }
}
