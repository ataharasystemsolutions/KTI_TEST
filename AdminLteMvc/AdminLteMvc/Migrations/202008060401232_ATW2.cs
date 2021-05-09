namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATW2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ATWs", "plateNo", c => c.String());
            AddColumn("dbo.ATWs", "issuedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ATWs", "issuedBy");
            DropColumn("dbo.ATWs", "plateNo");
        }
    }
}
