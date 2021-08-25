namespace SaundersRetail.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madechangestosales : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sale", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sale", "Quantity", c => c.Int(nullable: false));
        }
    }
}
