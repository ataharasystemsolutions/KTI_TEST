namespace AdminLteMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CargoType1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoTypes", "cargotype", c => c.String());
            DropColumn("dbo.CargoTypes", "congotype");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CargoTypes", "congotype", c => c.String());
            DropColumn("dbo.CargoTypes", "cargotype");
        }
    }
}
