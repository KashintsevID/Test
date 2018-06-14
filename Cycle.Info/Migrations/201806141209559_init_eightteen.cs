namespace Cycle.Info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_eightteen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bicycles", "StationId", "dbo.Stations");
            DropIndex("dbo.Bicycles", new[] { "StationId" });
            AlterColumn("dbo.Bicycles", "StationId", c => c.Int());
            CreateIndex("dbo.Bicycles", "StationId");
            AddForeignKey("dbo.Bicycles", "StationId", "dbo.Stations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bicycles", "StationId", "dbo.Stations");
            DropIndex("dbo.Bicycles", new[] { "StationId" });
            AlterColumn("dbo.Bicycles", "StationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bicycles", "StationId");
            AddForeignKey("dbo.Bicycles", "StationId", "dbo.Stations", "Id", cascadeDelete: true);
        }
    }
}
