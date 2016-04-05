namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTAReview : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TAReviews", "ParentID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TAReviews", "ParentID", c => c.Int(nullable: false));
        }
    }
}
