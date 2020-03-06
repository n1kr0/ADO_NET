namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCategoryFilters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FilterId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.FilterId, t.CategoryId })
                .ForeignKey("dbo.tblCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.tblFilters", t => t.FilterId, cascadeDelete: true)
                .Index(t => t.FilterId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.tblFilters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblFilterValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FilterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblFilters", t => t.FilterId, cascadeDelete: true)
                .Index(t => t.FilterId);
            
            CreateTable(
                "dbo.tblProductFilters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FilterId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.FilterId, t.ProductId })
                .ForeignKey("dbo.tblFilterValues", t => t.FilterId, cascadeDelete: true)
                .ForeignKey("dbo.tblProduct", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.FilterId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblCategoryFilters", "FilterId", "dbo.tblFilters");
            DropForeignKey("dbo.tblProductFilters", "ProductId", "dbo.tblProduct");
            DropForeignKey("dbo.tblProductFilters", "FilterId", "dbo.tblFilterValues");
            DropForeignKey("dbo.tblFilterValues", "FilterId", "dbo.tblFilters");
            DropForeignKey("dbo.tblCategoryFilters", "CategoryId", "dbo.tblCategories");
            DropIndex("dbo.tblProductFilters", new[] { "ProductId" });
            DropIndex("dbo.tblProductFilters", new[] { "FilterId" });
            DropIndex("dbo.tblFilterValues", new[] { "FilterId" });
            DropIndex("dbo.tblCategoryFilters", new[] { "CategoryId" });
            DropIndex("dbo.tblCategoryFilters", new[] { "FilterId" });
            DropTable("dbo.tblProductFilters");
            DropTable("dbo.tblFilterValues");
            DropTable("dbo.tblFilters");
            DropTable("dbo.tblCategoryFilters");
        }
    }
}
