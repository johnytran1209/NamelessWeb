namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "UserName");
        }
    }
}
