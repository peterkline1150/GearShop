namespace GearShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedIndividualGear : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.IndividualGear", "GearId");
            AddForeignKey("dbo.IndividualGear", "GearId", "dbo.Gear", "GearId", cascadeDelete: true);
            DropColumn("dbo.IndividualGear", "GearNameInCart");
            DropColumn("dbo.IndividualGear", "CostOfGear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndividualGear", "CostOfGear", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.IndividualGear", "GearNameInCart", c => c.String(nullable: false));
            DropForeignKey("dbo.IndividualGear", "GearId", "dbo.Gear");
            DropIndex("dbo.IndividualGear", new[] { "GearId" });
        }
    }
}
