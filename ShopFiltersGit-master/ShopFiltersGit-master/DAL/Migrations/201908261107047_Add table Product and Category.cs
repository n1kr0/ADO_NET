namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtableProductandCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Price = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProduct", "CategoryId", "dbo.tblCategories");
            DropIndex("dbo.tblProduct", new[] { "CategoryId" });
            DropTable("dbo.tblProduct");
            DropTable("dbo.tblCategories");
        }
    }
}
