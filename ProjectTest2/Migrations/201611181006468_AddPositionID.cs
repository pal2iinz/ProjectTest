namespace ProjectTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPositionID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "PositionID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "PositionID");
        }
    }
}
