namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATW : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ATWs",
                c => new
                    {
                        atwID = c.Int(nullable: false, identity: true),
                        atwBkNo = c.String(),
                        bkNo = c.String(),
                        iDate = c.String(),
                        eDate = c.String(),
                        aTrucker = c.String(),
                        aDriver = c.String(),
                        cShipper = c.String(),
                        conPerson = c.String(),
                        consignee = c.String(),
                        cargo = c.String(),
                        serviceMode = c.String(),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.atwID);
            
            DropTable("dbo.Shippers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        shipperID = c.Int(nullable: false, identity: true),
                        shprName = c.String(),
                    })
                .PrimaryKey(t => t.shipperID);
            
            DropTable("dbo.ATWs");
        }
    }
}
