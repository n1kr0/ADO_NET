namespace CodeFirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblPerconCreditInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CreditCardNumber = c.String(),
                        Percent = c.Double(nullable: false),
                        Ballance = c.Double(nullable: false),
                        Sum = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblPersons", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblPerconCreditInfoes", "Id", "dbo.tblPersons");
            DropIndex("dbo.tblPerconCreditInfoes", new[] { "Id" });
            DropTable("dbo.tblPerconCreditInfoes");
        }
    }
}
