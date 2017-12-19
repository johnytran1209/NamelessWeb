namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBangDangKyLichLamViec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LichLamViecModels",
                c => new
                    {
                        idLich = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.idLich);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LichLamViecModels");
        }
    }
}
