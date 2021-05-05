namespace ZaropaMVC.Migrations.ZaropaContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        BuyButton = c.String(),
                        ImageUrl = c.String(),
                        Tier = c.String(),
                        ShoeName = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Tier = c.String(),
                    })
                .PrimaryKey(t => t.Id);

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
            DropTable("dbo.Shoes");
            DropTable("dbo.Product");
            DropTable("dbo.Sales");
        }
    }
}
