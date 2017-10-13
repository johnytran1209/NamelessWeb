namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newquesandans : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Question", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.AspNetUsers", "Answer", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Answer");
            DropColumn("dbo.AspNetUsers", "Question");
        }
    }
}
