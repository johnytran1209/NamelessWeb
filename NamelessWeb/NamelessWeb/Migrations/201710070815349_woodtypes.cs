namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woodtypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoBacks",
                c => new
                    {
                        BackId = c.String(nullable: false, maxLength: 3),
                        BackName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.BackId);
            
            CreateTable(
                "dbo.GoFings",
                c => new
                    {
                        FingId = c.String(nullable: false, maxLength: 3),
                        FingName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.FingId);
            
            CreateTable(
                "dbo.GoNecks",
                c => new
                    {
                        NeckId = c.String(nullable: false, maxLength: 3),
                        NeckName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.NeckId);
            
            CreateTable(
                "dbo.GoSides",
                c => new
                    {
                        SideId = c.String(nullable: false, maxLength: 3),
                        SideName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.SideId);
            
            CreateTable(
                "dbo.GoTops",
                c => new
                    {
                        TopId = c.String(nullable: false, maxLength: 3),
                        TopName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.TopId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GoTops");
            DropTable("dbo.GoSides");
            DropTable("dbo.GoNecks");
            DropTable("dbo.GoFings");
            DropTable("dbo.GoBacks");
        }
    }
}
