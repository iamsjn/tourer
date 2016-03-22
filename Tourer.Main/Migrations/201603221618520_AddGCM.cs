namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGCM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GCMs",
                c => new
                    {
                        GCMID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        GCMNo = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.GCMID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GCMs", "UserID", "dbo.Users");
            DropIndex("dbo.GCMs", new[] { "UserID" });
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Users", "ModifiedDate");
            DropColumn("dbo.Users", "CreatedDate");
            DropTable("dbo.GCMs");
        }
    }
}
