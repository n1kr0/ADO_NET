namespace PostExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createtableposts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false),
                        DataEndUpdate = c.DateTime(nullable: false),
                        DataOfCreate = c.DateTime(nullable: false),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblPosts");
        }
    }
}
