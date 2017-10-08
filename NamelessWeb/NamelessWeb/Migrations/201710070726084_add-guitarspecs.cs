namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addguitarspecs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guitars",
                c => new
                    {
                        GuitarId = c.String(nullable: false, maxLength: 20),
                        MDL = c.String(nullable: false, maxLength: 40),
                        BrandId = c.String(nullable: false, maxLength: 3),
                        TypeId = c.String(nullable: false, maxLength: 3),
                        SL = c.Int(nullable: false),
                        MSRP = c.Single(nullable: false),
                        BH = c.Int(nullable: false),
                        ELE = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.GuitarId);
            
            CreateTable(
                "dbo.GuitarSpecs",
                c => new
                    {
                        GuitarId = c.String(nullable: false, maxLength: 40),
                        TopId = c.String(nullable: false, maxLength: 3),
                        SideId = c.String(nullable: false, maxLength: 3),
                        BackId = c.String(nullable: false, maxLength: 3),
                        NeckId = c.String(nullable: false, maxLength: 3),
                        FingId = c.String(nullable: false, maxLength: 3),
                        Descript = c.String(nullable: false, maxLength: 1200),
                    })
                .PrimaryKey(t => t.GuitarId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuitarSpecs");
            DropTable("dbo.Guitars");
        }
    }
}
