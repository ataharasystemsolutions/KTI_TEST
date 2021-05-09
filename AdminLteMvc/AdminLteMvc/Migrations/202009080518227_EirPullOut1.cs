namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EirPullOut1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EirPullOuts", "EIROYear", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EirPullOuts", "EIROYear");
        }
    }
}
