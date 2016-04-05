namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableTAPhoto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TAPhotoes",
                c => new
                    {
                        TAPhotoID = c.Int(nullable: false, identity: true),
                        TouristAttractionID = c.Int(nullable: false),
                        Photo = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.TAPhotoID);
            
            AddColumn("dbo.TouristAttractions", "Photo", c => c.String());
            AddColumn("dbo.TouristAttractions", "BannerPhoto", c => c.String());
            DropColumn("dbo.TouristAttractions", "PhotoOne");
            DropColumn("dbo.TouristAttractions", "PhotoTwo");
            DropColumn("dbo.TouristAttractions", "PhotoThree");
            DropColumn("dbo.TouristAttractions", "PhotoFour");
            DropColumn("dbo.TouristAttractions", "PhotoFive");
            DropColumn("dbo.TouristAttractions", "PhotoSix");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TouristAttractions", "PhotoSix", c => c.String());
            AddColumn("dbo.TouristAttractions", "PhotoFive", c => c.String());
            AddColumn("dbo.TouristAttractions", "PhotoFour", c => c.String());
            AddColumn("dbo.TouristAttractions", "PhotoThree", c => c.String());
            AddColumn("dbo.TouristAttractions", "PhotoTwo", c => c.String());
            AddColumn("dbo.TouristAttractions", "PhotoOne", c => c.String());
            DropColumn("dbo.TouristAttractions", "BannerPhoto");
            DropColumn("dbo.TouristAttractions", "Photo");
            DropTable("dbo.TAPhotoes");
        }
    }
}
