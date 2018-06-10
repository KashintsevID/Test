namespace Cycle.Info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_one : DbMigration
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        CardNumber = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BikeTaken = c.Int(nullable: false),
                        BeginingOfRent = c.DateTime(nullable: false),
                        Bicycle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bicycles", t => t.Bicycle_Id)
                .Index(t => t.Bicycle_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Bicycle_Id", "dbo.Bicycles");
            DropForeignKey("dbo.Bicycles", "StationId", "dbo.Stations");
            DropIndex("dbo.Users", new[] { "Bicycle_Id" });
            DropIndex("dbo.Bicycles", new[] { "StationId" });
            DropTable("dbo.Users");
            DropTable("dbo.Stations");
            DropTable("dbo.Bicycles");
        }
    }
}
