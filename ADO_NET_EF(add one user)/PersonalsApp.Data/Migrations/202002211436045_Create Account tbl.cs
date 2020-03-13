namespace PersonalsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAccounttbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAccount",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Login = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblAccount", "Id", "dbo.tblUsers");
            DropIndex("dbo.tblAccount", new[] { "Id" });
            DropTable("dbo.tblAccount");
        }
    }
}
