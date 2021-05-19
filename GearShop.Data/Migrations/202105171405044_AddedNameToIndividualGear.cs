namespace GearShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameToIndividualGear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndividualGear", "NameOfGear", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndividualGear", "NameOfGear");
        }
    }
}
