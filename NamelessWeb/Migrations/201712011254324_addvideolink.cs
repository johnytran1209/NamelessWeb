namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvideolink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guitars", "Videolink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Guitars", "Videolink");
        }
    }
}
