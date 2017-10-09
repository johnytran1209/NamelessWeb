namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBH1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warranties",
                c => new
                    {
                        WarrId = c.Int(nullable: false, identity: true),
                        WarrLength = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WarrId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Warranties");
        }
    }
}
