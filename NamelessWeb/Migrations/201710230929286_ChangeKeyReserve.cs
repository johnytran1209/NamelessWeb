namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeKeyReserve : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Reservations");
            AlterColumn("dbo.Reservations", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "GuitarId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Reservations", "GuitarId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Reservations");
            AlterColumn("dbo.Reservations", "GuitarId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Reservations", "UserId");
        }
    }
}
