namespace Cycle.Info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini_thirteen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rides", "TotalRideTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rides", "TotalRideTime", c => c.Int(nullable: false));
        }
    }
}
