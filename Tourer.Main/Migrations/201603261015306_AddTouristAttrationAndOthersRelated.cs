namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTouristAttrationAndOthersRelated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Longitude = c.String(),
                        Latitude = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        SeasonID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SeasonID);
            
            CreateTable(
                "dbo.TAttractionAndSeasons",
                c => new
                    {
                        TAttractionAndSeasonID = c.Int(nullable: false, identity: true),
                        SeasonID = c.Int(nullable: false),
                        TouristAttractionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TAttractionAndSeasonID);
            
            CreateTable(
                "dbo.TouristAttractions",
                c => new
                    {
                        TouristAttractionID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        PhotoOne = c.String(),
                        PhotoTwo = c.String(),
                        PhotoThree = c.String(),
                        PhotoFour = c.String(),
                        PhotoFive = c.String(),
                        PhotoSix = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.TouristAttractionID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TouristAttractions", "LocationID", "dbo.Locations");
            DropIndex("dbo.TouristAttractions", new[] { "LocationID" });
            DropTable("dbo.TouristAttractions");
            DropTable("dbo.TAttractionAndSeasons");
            DropTable("dbo.Seasons");
            DropTable("dbo.Locations");
        }
    }
}
