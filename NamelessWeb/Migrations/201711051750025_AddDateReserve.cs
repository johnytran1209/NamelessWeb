namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateReserve : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "DateReserve", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "DateReserve");
        }
    }
}
