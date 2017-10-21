namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Guitars", "ImageLink", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Guitars", "ImageLink", c => c.String(nullable: false));
        }
    }
}
