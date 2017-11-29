namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morepic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guitars", "ImageLink1", c => c.String());
            AddColumn("dbo.Guitars", "ImageLink2", c => c.String());
            AddColumn("dbo.Guitars", "ImageLink3", c => c.String());
            AddColumn("dbo.Guitars", "ImageLink4", c => c.String());
            AddColumn("dbo.Guitars", "ImageLink5", c => c.String());
            AddColumn("dbo.Guitars", "ImageLink6", c => c.String());
            DropColumn("dbo.Guitars", "ImageLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Guitars", "ImageLink", c => c.String());
            DropColumn("dbo.Guitars", "ImageLink6");
            DropColumn("dbo.Guitars", "ImageLink5");
            DropColumn("dbo.Guitars", "ImageLink4");
            DropColumn("dbo.Guitars", "ImageLink3");
            DropColumn("dbo.Guitars", "ImageLink2");
            DropColumn("dbo.Guitars", "ImageLink1");
        }
    }
}
