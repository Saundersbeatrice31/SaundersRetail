namespace SaundersRetail.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madealotofchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cashier",
                c => new
                    {
                        CashierID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.CashierID);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        CashierID = c.Guid(nullable: false),
                        SaleDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Quantity = c.Int(nullable: false),
                        CashID = c.Int(),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.Cashier", t => t.CashID)
                .Index(t => t.CashID);
            
            CreateTable(
                "dbo.InventorySale",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        SaleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.SaleID })
                .ForeignKey("dbo.Inventory", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Sale", t => t.SaleID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.SaleID);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ImagePath = c.String(),
                        RetailPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityInStock = c.Int(nullable: false),
                        IsTaxable = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        LastModified = c.DateTimeOffset(precision: 7),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventory", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductSale",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        SaleID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.SaleID })
                .ForeignKey("dbo.Product", t => t.ID, cascadeDelete: true)
                .ForeignKey("dbo.Sale", t => t.SaleID, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.SaleID);
            
            CreateTable(
                "dbo.ProductSaleData",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        SDID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.SDID })
                .ForeignKey("dbo.Product", t => t.ID, cascadeDelete: true)
                .ForeignKey("dbo.SaleData", t => t.SDID, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.SDID);
            
            CreateTable(
                "dbo.SaleData",
                c => new
                    {
                        SDID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ID = c.Int(),
                    })
                .PrimaryKey(t => t.SDID)
                .ForeignKey("dbo.Inventory", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.InventorySale", "SaleID", "dbo.Sale");
            DropForeignKey("dbo.InventorySale", "ProductID", "dbo.Inventory");
            DropForeignKey("dbo.ProductSaleData", "SDID", "dbo.SaleData");
            DropForeignKey("dbo.SaleData", "ID", "dbo.Inventory");
            DropForeignKey("dbo.ProductSaleData", "ID", "dbo.Product");
            DropForeignKey("dbo.ProductSale", "SaleID", "dbo.Sale");
            DropForeignKey("dbo.ProductSale", "ID", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductID", "dbo.Inventory");
            DropForeignKey("dbo.Sale", "CashID", "dbo.Cashier");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.SaleData", new[] { "ID" });
            DropIndex("dbo.ProductSaleData", new[] { "SDID" });
            DropIndex("dbo.ProductSaleData", new[] { "ID" });
            DropIndex("dbo.ProductSale", new[] { "SaleID" });
            DropIndex("dbo.ProductSale", new[] { "ID" });
            DropIndex("dbo.Product", new[] { "ProductID" });
            DropIndex("dbo.InventorySale", new[] { "SaleID" });
            DropIndex("dbo.InventorySale", new[] { "ProductID" });
            DropIndex("dbo.Sale", new[] { "CashID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.SaleData");
            DropTable("dbo.ProductSaleData");
            DropTable("dbo.ProductSale");
            DropTable("dbo.Product");
            DropTable("dbo.Inventory");
            DropTable("dbo.InventorySale");
            DropTable("dbo.Sale");
            DropTable("dbo.Cashier");
        }
    }
}
