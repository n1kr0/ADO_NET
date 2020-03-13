namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Category = c.Int(nullable: false),
                        Price = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategory", t => t.Category, cascadeDelete: true)
                .Index(t => t.Category);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProduct", "Category", "dbo.tblCategory");
            DropIndex("dbo.tblProduct", new[] { "Category" });
            DropTable("dbo.tblProduct");
            DropTable("dbo.tblCategory");
        }
    }
}
