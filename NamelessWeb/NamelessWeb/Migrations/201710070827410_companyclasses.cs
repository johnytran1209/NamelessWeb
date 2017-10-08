namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.String(nullable: false, maxLength: 3),
                        BrandName = c.String(nullable: false, maxLength: 40),
                        SuppId = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SuppId = c.String(nullable: false, maxLength: 3),
                        SuppName = c.String(nullable: false, maxLength: 50),
                        SuppEmail = c.String(nullable: false, maxLength: 50),
                        SuppPhone = c.String(nullable: false, maxLength: 20),
                        SuppWeb = c.String(nullable: false, maxLength: 50),
                        SuppAddr = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.SuppId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suppliers");
            DropTable("dbo.Brands");
        }
    }
}
