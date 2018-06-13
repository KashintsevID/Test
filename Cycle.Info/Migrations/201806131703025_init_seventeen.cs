namespace Cycle.Info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_seventeen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "CardNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CardNumber", c => c.Int(nullable: false));
        }
    }
}
