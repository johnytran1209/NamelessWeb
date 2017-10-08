namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSystemtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuitarRatings",
                c => new
                    {
                        FeedId = c.String(nullable: false, maxLength: 128),
                        GuitarId = c.String(),
                        CusName = c.String(),
                        Stars = c.Int(nullable: false),
                        FeedMes = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.FeedId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.String(nullable: false, maxLength: 128),
                        NoteMess = c.String(),
                    })
                .PrimaryKey(t => t.NoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notes");
            DropTable("dbo.GuitarRatings");
        }
    }
}
