namespace SaundersRetail.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedProductSaleData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSaleData", "ProductName", c => c.String());
            AddColumn("dbo.ProductSaleData", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSaleData", "Quantity");
            DropColumn("dbo.ProductSaleData", "ProductName");
        }
    }
}
