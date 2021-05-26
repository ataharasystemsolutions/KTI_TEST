namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202105260154473_AutomaticMigration : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE onboardVesselLoadItems DROP CONSTRAINT [DF__onboardVe__billo__2EFAF1E2]");
            AlterColumn("dbo.onboardVesselLoadItems", "billofLadingNo", c => c.String());
        }
        
        public override void Down()
        {
            Sql("ALTER TABLE onboardVesselLoadItems DROP CONSTRAINT [DF__onboardVe__billo__2EFAF1E2]");
            AlterColumn("dbo.onboardVesselLoadItems", "billofLadingNo", c => c.Int(nullable: false));
        }
    }
}
