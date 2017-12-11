namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNoteId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Notes");
            CreateTable(
                "dbo.NoteViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Messeage = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Notes", "NoteId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Notes", "NoteId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Notes");
            AlterColumn("dbo.Notes", "NoteId", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.NoteViewModels");
            AddPrimaryKey("dbo.Notes", "NoteId");
        }
    }
}
