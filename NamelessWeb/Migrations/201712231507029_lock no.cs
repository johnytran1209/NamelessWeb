namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lockno : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Lock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Lock", c => c.Boolean(nullable: false));
        }
    }
}
