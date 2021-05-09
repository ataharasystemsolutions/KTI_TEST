namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATW8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ATWs", "convanno1", c => c.String());
            AddColumn("dbo.ATWs", "convanno2", c => c.String());
            AddColumn("dbo.ATWs", "shipperno1", c => c.String());
            AddColumn("dbo.ATWs", "shipperno2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ATWs", "shipperno2");
            DropColumn("dbo.ATWs", "shipperno1");
            DropColumn("dbo.ATWs", "convanno2");
            DropColumn("dbo.ATWs", "convanno1");
        }
    }
}
