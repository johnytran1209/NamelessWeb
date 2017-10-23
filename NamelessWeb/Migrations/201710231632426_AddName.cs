namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
