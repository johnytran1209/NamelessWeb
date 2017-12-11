namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "NoteMess", c => c.String(nullable: false));
            AlterColumn("dbo.Notes", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "UserName", c => c.String());
            AlterColumn("dbo.Notes", "NoteMess", c => c.String());
        }
    }
}
