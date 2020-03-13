namespace PersonalsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtblRolesandtblUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false),
                        Image = c.String(nullable: false, maxLength: 100),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUsers", "RoleId", "dbo.tblRoles");
            DropIndex("dbo.tblUsers", new[] { "RoleId" });
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblRoles");
        }
    }
}
