namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EIRIn1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EIRIns", "EIRIRemarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EIRIns", "EIRIRemarks");
        }
    }
}
