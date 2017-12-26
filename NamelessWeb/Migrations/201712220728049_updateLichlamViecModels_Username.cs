namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLichlamViecModels_Username : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichLamViecModels", "userName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichLamViecModels", "userName");
        }
    }
}
