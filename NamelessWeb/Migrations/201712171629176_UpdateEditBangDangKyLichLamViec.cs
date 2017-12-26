namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEditBangDangKyLichLamViec : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichLamViecModels", "idUser", c => c.String());
            AddColumn("dbo.LichLamViecModels", "sang2", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "sang3", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "sang4", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "sang5", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "sang6", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "sang7", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "sangCN", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "chieu2", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "chieu3", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "chieu4", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "chieu5", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "chieu6", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "chieu7", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichLamViecModels", "chieuCN", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichLamViecModels", "chieuCN");
            DropColumn("dbo.LichLamViecModels", "chieu7");
            DropColumn("dbo.LichLamViecModels", "chieu6");
            DropColumn("dbo.LichLamViecModels", "chieu5");
            DropColumn("dbo.LichLamViecModels", "chieu4");
            DropColumn("dbo.LichLamViecModels", "chieu3");
            DropColumn("dbo.LichLamViecModels", "chieu2");
            DropColumn("dbo.LichLamViecModels", "sangCN");
            DropColumn("dbo.LichLamViecModels", "sang7");
            DropColumn("dbo.LichLamViecModels", "sang6");
            DropColumn("dbo.LichLamViecModels", "sang5");
            DropColumn("dbo.LichLamViecModels", "sang4");
            DropColumn("dbo.LichLamViecModels", "sang3");
            DropColumn("dbo.LichLamViecModels", "sang2");
            DropColumn("dbo.LichLamViecModels", "idUser");
        }
    }
}
