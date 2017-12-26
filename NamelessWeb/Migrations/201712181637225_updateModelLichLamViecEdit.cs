namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModelLichLamViecEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichLamViecModels", "heading", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichLamViecModels", "heading");
        }
    }
}
