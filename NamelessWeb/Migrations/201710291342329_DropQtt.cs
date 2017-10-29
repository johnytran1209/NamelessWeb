namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropQtt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ExpBillDetails", "Qtt");
            DropColumn("dbo.ImpBillDetails", "Qtt");
            DropColumn("dbo.OrdBillDetails", "Qtt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrdBillDetails", "Qtt", c => c.Int(nullable: false));
            AddColumn("dbo.ImpBillDetails", "Qtt", c => c.Int(nullable: false));
            AddColumn("dbo.ExpBillDetails", "Qtt", c => c.Int(nullable: false));
        }
    }
}
