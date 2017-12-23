namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notoreserve : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Reservations");
            AddColumn("dbo.Reservations", "No", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Reservations", "GuitarId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Reservations", "No");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Reservations");
            AlterColumn("dbo.Reservations", "GuitarId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Reservations", "No");
            AddPrimaryKey("dbo.Reservations", "GuitarId");
        }
    }
}
