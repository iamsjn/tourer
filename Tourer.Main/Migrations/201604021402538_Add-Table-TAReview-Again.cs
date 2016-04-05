namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableTAReviewAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TAReviews",
                c => new
                    {
                        TAReviewID = c.Int(nullable: false, identity: true),
                        TouristAttractionID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ParentID = c.Int(),
                        Rating = c.Int(nullable: false),
                        Review = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.TAReviewID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TAReviews");
        }
    }
}
