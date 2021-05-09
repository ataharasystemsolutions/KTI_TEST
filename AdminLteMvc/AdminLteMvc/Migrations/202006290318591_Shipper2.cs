namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shipper2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippers", "shprName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shippers", "shprName");
        }
    }
}
