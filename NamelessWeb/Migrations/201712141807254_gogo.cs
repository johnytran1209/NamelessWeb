namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gogo : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GuitarRatings");
            AlterColumn("dbo.GuitarRatings", "FeedId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GuitarRatings", "FeedId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GuitarRatings");
            AlterColumn("dbo.GuitarRatings", "FeedId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.GuitarRatings", "FeedId");
        }
    }
}
