namespace Cycle.Info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_sixten : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bicycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StationId = c.Int(nullable: false),
                        CurrentSlot = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stations", t => t.StationId, cascadeDelete: true)
                .Index(t => t.StationId);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adress = c.String(),
                        NearestMetroStation = c.String(),
                        NumberOfSlots = c.Int(nullable: false),
                        NumberOfBikes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BicycleId = c.Int(nullable: false),
                        BeginingOfRide = c.DateTime(nullable: false),
                        TotalRideTime = c.String(),
                        MoneyPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsRideFinished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bicycles", t => t.BicycleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BicycleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        CardNumber = c.Int(nullable: false),
                        CardPassword = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rides", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rides", "BicycleId", "dbo.Bicycles");
            DropForeignKey("dbo.Bicycles", "StationId", "dbo.Stations");
            DropIndex("dbo.Rides", new[] { "BicycleId" });
            DropIndex("dbo.Rides", new[] { "UserId" });
            DropIndex("dbo.Bicycles", new[] { "StationId" });
            DropTable("dbo.Users");
            DropTable("dbo.Rides");
            DropTable("dbo.Stations");
            DropTable("dbo.Bicycles");
        }
    }
}
