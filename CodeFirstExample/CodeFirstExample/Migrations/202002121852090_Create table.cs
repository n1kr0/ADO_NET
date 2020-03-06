namespace CodeFirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblPersonOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Number = c.String(maxLength: 100),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblPersons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblPersonOrders", "PersonId", "dbo.tblPersons");
            DropIndex("dbo.tblPersonOrders", new[] { "PersonId" });
            DropTable("dbo.tblPersonOrders");
        }
    }
}
