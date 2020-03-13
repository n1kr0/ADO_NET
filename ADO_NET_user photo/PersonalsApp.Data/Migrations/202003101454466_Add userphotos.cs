namespace PersonalsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adduserphotos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUserPhotos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUserPhotos", "User_Id", "dbo.tblUsers");
            DropIndex("dbo.tblUserPhotos", new[] { "User_Id" });
            DropTable("dbo.tblUserPhotos");
        }
    }
}
