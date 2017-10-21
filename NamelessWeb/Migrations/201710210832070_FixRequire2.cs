namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRequire2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GuitarSpecs", "Descript", c => c.String(maxLength: 1200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GuitarSpecs", "Descript", c => c.String(nullable: false, maxLength: 1200));
        }
    }
}
