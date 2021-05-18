namespace GearShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingCartAgain1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndividualGear", "CartId", "dbo.Cart");
            DropForeignKey("dbo.IndividualGear", "GearId", "dbo.Gear");
            DropIndex("dbo.IndividualGear", new[] { "GearId" });
            DropIndex("dbo.IndividualGear", new[] { "CartId" });
            AlterColumn("dbo.IndividualGear", "GearId", c => c.Int());
            AlterColumn("dbo.IndividualGear", "CartId", c => c.Int());
            CreateIndex("dbo.IndividualGear", "GearId");
            CreateIndex("dbo.IndividualGear", "CartId");
            AddForeignKey("dbo.IndividualGear", "CartId", "dbo.Cart", "CartId");
            AddForeignKey("dbo.IndividualGear", "GearId", "dbo.Gear", "GearId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndividualGear", "GearId", "dbo.Gear");
            DropForeignKey("dbo.IndividualGear", "CartId", "dbo.Cart");
            DropIndex("dbo.IndividualGear", new[] { "CartId" });
            DropIndex("dbo.IndividualGear", new[] { "GearId" });
            AlterColumn("dbo.IndividualGear", "CartId", c => c.Int(nullable: false));
            AlterColumn("dbo.IndividualGear", "GearId", c => c.Int(nullable: false));
            CreateIndex("dbo.IndividualGear", "CartId");
            CreateIndex("dbo.IndividualGear", "GearId");
            AddForeignKey("dbo.IndividualGear", "GearId", "dbo.Gear", "GearId", cascadeDelete: true);
            AddForeignKey("dbo.IndividualGear", "CartId", "dbo.Cart", "CartId", cascadeDelete: true);
        }
    }
}
