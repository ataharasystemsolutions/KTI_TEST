namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATW6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ATWs", "cvno", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ATWs", "cvno");
        }
    }
}
