namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Guitars");
            DropPrimaryKey("dbo.GuitarSpecs");
            AddColumn("dbo.Guitars", "ImageLink", c => c.String());
            AlterColumn("dbo.Guitars", "GuitarId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.GuitarSpecs", "GuitarId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.GuitarSpecs", "Descript", c => c.String(maxLength: 1200));
            AddPrimaryKey("dbo.Guitars", "GuitarId");
            AddPrimaryKey("dbo.GuitarSpecs", "GuitarId");
            DropColumn("dbo.Guitars", "SL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Guitars", "SL", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.GuitarSpecs");
            DropPrimaryKey("dbo.Guitars");
            AlterColumn("dbo.GuitarSpecs", "Descript", c => c.String(nullable: false, maxLength: 1200));
            AlterColumn("dbo.GuitarSpecs", "GuitarId", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Guitars", "GuitarId", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Guitars", "ImageLink");
            AddPrimaryKey("dbo.GuitarSpecs", "GuitarId");
            AddPrimaryKey("dbo.Guitars", "GuitarId");
        }
    }
}
