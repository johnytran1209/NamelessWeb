namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuitarTypes",
                c => new
                    {
                        TypeId = c.String(nullable: false, maxLength: 3),
                        TypeName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuitarTypes");
        }
    }
}
