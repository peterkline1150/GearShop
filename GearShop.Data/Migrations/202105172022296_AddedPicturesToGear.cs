namespace GearShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPicturesToGear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gear", "PictureUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gear", "PictureUrl");
        }
    }
}
