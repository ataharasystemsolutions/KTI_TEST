namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EirPullOut3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EirPullOuts", "EIROStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EirPullOuts", "EIROStatus");
        }
    }
}
