namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTADetailRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TADetails",
                c => new
                    {
                        TADetailID = c.Int(nullable: false, identity: true),
                        TouristAttractionID = c.Int(nullable: false),
                        Detail = c.String(),
                    })
                .PrimaryKey(t => t.TADetailID);
            
            AddColumn("dbo.TouristAttractions", "TADetail_TADetailID", c => c.Int());
            CreateIndex("dbo.TouristAttractions", "TADetail_TADetailID");
            AddForeignKey("dbo.TouristAttractions", "TADetail_TADetailID", "dbo.TADetails", "TADetailID");
            DropColumn("dbo.Seasons", "FromDate");
            DropColumn("dbo.Seasons", "ToDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seasons", "ToDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Seasons", "FromDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.TouristAttractions", "TADetail_TADetailID", "dbo.TADetails");
            DropIndex("dbo.TouristAttractions", new[] { "TADetail_TADetailID" });
            DropColumn("dbo.TouristAttractions", "TADetail_TADetailID");
            DropTable("dbo.TADetails");
        }
    }
}
