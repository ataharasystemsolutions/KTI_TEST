namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EirPullOut2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EirPullOuts", "EIROYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EirPullOuts", "EIROYear", c => c.String());
        }
    }
}
