namespace ProjectTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class U11 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "Role");
            RenameTable(name: "dbo.Position", newName: "AccountPosition");
            RenameColumn(table: "dbo.AccountPosition", name: "RoleId", newName: "PositionID");
            RenameIndex(table: "dbo.AccountPosition", name: "IX_RoleId", newName: "IX_PositionID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AccountPosition", name: "IX_PositionID", newName: "IX_RoleId");
            RenameColumn(table: "dbo.AccountPosition", name: "PositionID", newName: "RoleId");
            RenameTable(name: "dbo.AccountPosition", newName: "Position");
            RenameTable(name: "dbo.Role", newName: "AspNetRoles");
        }
    }
}
