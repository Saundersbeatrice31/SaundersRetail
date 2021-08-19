namespace SaundersRetail.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madechangestoSaleData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventorySale", "ProductName", c => c.String());
            AddColumn("dbo.InventorySale", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSale", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSale", "ProductName");
            DropColumn("dbo.InventorySale", "Quantity");
            DropColumn("dbo.InventorySale", "ProductName");
        }
    }
}
