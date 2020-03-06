namespace CodeFirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializeprojectandaddpercons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DatoOfBirth = c.DateTime(nullable: false),
                        Descripton = c.String(),
                        Gender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblPersons");
        }
    }
}
