namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guitaridtoexpde : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpBillDetails", "GuitarId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpBillDetails", "GuitarId");
        }
    }
}
