namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeidforguitarratings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GuitarRatings", "GuitarId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GuitarRatings", "GuitarId", c => c.String());
        }
    }
}
