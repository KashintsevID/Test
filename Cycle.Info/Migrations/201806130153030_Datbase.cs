namespace Cycle.Info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datbase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "CardNumber", c => c.String());
            AlterColumn("dbo.Users", "CardPassword", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CardPassword", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "CardNumber", c => c.Int(nullable: false));
        }
    }
}
