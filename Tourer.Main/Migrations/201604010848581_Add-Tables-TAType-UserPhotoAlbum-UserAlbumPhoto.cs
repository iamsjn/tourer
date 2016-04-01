namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesTATypeUserPhotoAlbumUserAlbumPhoto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TATypes",
                c => new
                    {
                        TATypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.TATypeID);
            
            CreateTable(
                "dbo.UserAlbumPhotoes",
                c => new
                    {
                        UserAlbumPhotoID = c.Int(nullable: false, identity: true),
                        UserPhotoAlbumID = c.Int(nullable: false),
                        PhotoPath = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserAlbumPhotoID)
                .ForeignKey("dbo.UserPhotoAlbums", t => t.UserPhotoAlbumID, cascadeDelete: true)
                .Index(t => t.UserPhotoAlbumID);
            
            CreateTable(
                "dbo.UserPhotoAlbums",
                c => new
                    {
                        UserPhotoAlbumID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TouristAttractionID = c.Int(nullable: false),
                        Privacy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserPhotoAlbumID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAlbumPhotoes", "UserPhotoAlbumID", "dbo.UserPhotoAlbums");
            DropIndex("dbo.UserAlbumPhotoes", new[] { "UserPhotoAlbumID" });
            DropTable("dbo.UserPhotoAlbums");
            DropTable("dbo.UserAlbumPhotoes");
            DropTable("dbo.TATypes");
        }
    }
}
