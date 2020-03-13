namespace PersonalsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteloginandpassword : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblUsers", "Login");
            DropColumn("dbo.tblUsers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUsers", "Password", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.tblUsers", "Login", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
