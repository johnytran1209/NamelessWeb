namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteNoteViewModels : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.NoteViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NoteViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Messeage = c.String(nullable: false),
                        UserName = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
