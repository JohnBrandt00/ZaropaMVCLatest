namespace ZaropaMVC.Migrations.ZaropaContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employees = c.Int(),
                        FirmName = c.String(),
                        FirmEmail = c.String(),
                        FirmPhoneNumber = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        SaleStatus = c.Int(nullable: false),
                        Profit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sales");
        }
    }
}
