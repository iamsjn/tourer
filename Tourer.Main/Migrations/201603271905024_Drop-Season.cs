namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropSeason : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TAttractionSeasonInfoes",
                c => new
                    {
                        TAttractionSeasonInfoID = c.Int(nullable: false, identity: true),
                        Season = c.Int(nullable: false),
                        TouristAttractionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TAttractionSeasonInfoID)
                .ForeignKey("dbo.TouristAttractions", t => t.TouristAttractionID, cascadeDelete: true)
                .Index(t => t.TouristAttractionID);
            
            DropTable("dbo.Seasons");
            DropTable("dbo.TAttractionAndSeasons");
        }
        
        public override void Down()
        {
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
                "dbo.Seasons",
                c => new
                    {
                        SeasonID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SeasonID);
            
            DropForeignKey("dbo.TAttractionSeasonInfoes", "TouristAttractionID", "dbo.TouristAttractions");
            DropIndex("dbo.TAttractionSeasonInfoes", new[] { "TouristAttractionID" });
            DropTable("dbo.TAttractionSeasonInfoes");
        }
    }
}
