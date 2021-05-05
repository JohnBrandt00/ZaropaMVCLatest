namespace ZaropaMVC.Migrations.ZaropaContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Retails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "RetailPrice", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "RetailPrice");
        }
    }
}
