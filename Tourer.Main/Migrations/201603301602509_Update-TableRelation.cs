namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TouristAttractions", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.TouristAttractions", "TADetail_TADetailID", "dbo.TADetails");
            DropIndex("dbo.TouristAttractions", new[] { "LocationID" });
            DropIndex("dbo.TouristAttractions", new[] { "TADetail_TADetailID" });
            DropColumn("dbo.TouristAttractions", "TADetail_TADetailID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TouristAttractions", "TADetail_TADetailID", c => c.Int());
            CreateIndex("dbo.TouristAttractions", "TADetail_TADetailID");
            CreateIndex("dbo.TouristAttractions", "LocationID");
            AddForeignKey("dbo.TouristAttractions", "TADetail_TADetailID", "dbo.TADetails", "TADetailID");
            AddForeignKey("dbo.TouristAttractions", "LocationID", "dbo.Locations", "LocationID", cascadeDelete: true);
        }
    }
}
