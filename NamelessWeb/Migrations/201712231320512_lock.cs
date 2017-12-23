namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _lock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Lock", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Lock");
        }
    }
}
