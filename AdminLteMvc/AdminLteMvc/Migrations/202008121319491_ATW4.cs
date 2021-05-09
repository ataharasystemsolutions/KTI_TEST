namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATW4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ATWs", "trns", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ATWs", "trns");
        }
    }
}
