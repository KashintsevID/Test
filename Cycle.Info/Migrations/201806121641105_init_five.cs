namespace Cycle.Info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_five : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BicycleId = c.Int(nullable: false),
                        BeginingOfRide = c.DateTime(nullable: false),
                        TotalRideTime = c.DateTime(nullable: false),
                        IsRideFinished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bicycles", t => t.BicycleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BicycleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rides", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rides", "BicycleId", "dbo.Bicycles");
            DropIndex("dbo.Rides", new[] { "BicycleId" });
            DropIndex("dbo.Rides", new[] { "UserId" });
            DropTable("dbo.Rides");
        }
    }
}
