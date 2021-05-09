namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignedBy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignedBies",
                c => new
                    {
                        assignedID = c.Int(nullable: false, identity: true),
                        assigned = c.String(),
                    })
                .PrimaryKey(t => t.assignedID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AssignedBies");
        }
    }
}
