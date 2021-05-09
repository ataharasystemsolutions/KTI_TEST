namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EirPullOut5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EirPullOuts", "EIROAtwBkNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EirPullOuts", "EIROAtwBkNo");
        }
    }
}
