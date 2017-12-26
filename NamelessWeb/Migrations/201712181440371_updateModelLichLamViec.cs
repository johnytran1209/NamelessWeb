namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModelLichLamViec : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichLamViecModels", "confirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichLamViecModels", "confirmed");
        }
    }
}
