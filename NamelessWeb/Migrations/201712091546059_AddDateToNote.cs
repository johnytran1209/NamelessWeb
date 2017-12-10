namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToNote : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NoteViewModels", "Messeage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NoteViewModels", "Messeage", c => c.String());
        }
    }
}
