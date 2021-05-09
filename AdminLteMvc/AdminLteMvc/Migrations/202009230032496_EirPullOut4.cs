namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EirPullOut4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EirPullOuts", "EIRORemarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EirPullOuts", "EIRORemarks");
        }
    }
}
