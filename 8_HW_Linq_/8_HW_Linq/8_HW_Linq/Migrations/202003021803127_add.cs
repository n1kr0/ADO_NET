namespace _8_HW_Linq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Goods", "Price", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Goods", "Price", c => c.Double(nullable: false));
        }
    }
}
