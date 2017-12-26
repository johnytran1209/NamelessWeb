namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBangPhanCongCongViec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangPhanCongCongViecs",
                c => new
                    {
                        idBangPhanCong = c.String(nullable: false, maxLength: 128),
                        idUser = c.String(),
                        thoigian = c.DateTime(nullable: false),
                        sang2 = c.Boolean(nullable: false),
                        sang3 = c.Boolean(nullable: false),
                        sang4 = c.Boolean(nullable: false),
                        sang5 = c.Boolean(nullable: false),
                        sang6 = c.Boolean(nullable: false),
                        sang7 = c.Boolean(nullable: false),
                        sangCN = c.Boolean(nullable: false),
                        chieu2 = c.Boolean(nullable: false),
                        chieu3 = c.Boolean(nullable: false),
                        chieu4 = c.Boolean(nullable: false),
                        chieu5 = c.Boolean(nullable: false),
                        chieu6 = c.Boolean(nullable: false),
                        chieu7 = c.Boolean(nullable: false),
                        chieuCN = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idBangPhanCong);
            
            DropColumn("dbo.LichLamViecModels", "confirmed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LichLamViecModels", "confirmed", c => c.Boolean(nullable: false));
            DropTable("dbo.BangPhanCongCongViecs");
        }
    }
}
