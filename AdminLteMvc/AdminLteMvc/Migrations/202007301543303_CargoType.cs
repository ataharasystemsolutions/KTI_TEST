namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CargoType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        congotype = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ContainerClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        conclass = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContainerClasses");
            DropTable("dbo.CargoTypes");
        }
    }
}
