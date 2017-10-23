namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guitars", "Availability", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Guitars", "Availability");
        }
    }
}
