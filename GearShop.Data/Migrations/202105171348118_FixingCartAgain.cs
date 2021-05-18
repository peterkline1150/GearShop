namespace GearShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingCartAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndividualGear", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndividualGear", "Price");
        }
    }
}
