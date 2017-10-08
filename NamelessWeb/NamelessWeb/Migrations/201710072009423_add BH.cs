namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBH : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guitars", "WarrId", c => c.Int(nullable: false));
            DropColumn("dbo.Guitars", "BH");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Guitars", "BH", c => c.Int(nullable: false));
            DropColumn("dbo.Guitars", "WarrId");
        }
    }
}
