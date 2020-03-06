namespace Lab3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblGoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Single(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblGoods");
        }
    }
}
