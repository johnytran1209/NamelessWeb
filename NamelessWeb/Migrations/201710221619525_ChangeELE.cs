namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeELE : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Guitars", "ELE", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Guitars", "ELE", c => c.Byte(nullable: false));
        }
    }
}
