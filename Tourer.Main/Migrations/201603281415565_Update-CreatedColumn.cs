namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCreatedColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Locations", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.TADetails", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TADetails", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.TAttractionSeasonInfoes", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TAttractionSeasonInfoes", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TAttractionSeasonInfoes", "ModifiedDate");
            DropColumn("dbo.TAttractionSeasonInfoes", "CreatedDate");
            DropColumn("dbo.TADetails", "ModifiedDate");
            DropColumn("dbo.TADetails", "CreatedDate");
            DropColumn("dbo.Locations", "ModifiedDate");
            DropColumn("dbo.Locations", "CreatedDate");
        }
    }
}
