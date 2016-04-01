namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "ParentID", c => c.Int());
            AddColumn("dbo.TouristAttractions", "TATypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.TouristAttractions", "TATypeID");
            DropColumn("dbo.Locations", "ParentID");
        }
    }
}
