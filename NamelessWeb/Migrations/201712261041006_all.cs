namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LichLamViecModels");
            DropTable("dbo.BangPhanCongCongViecs");
        }
    }
}
