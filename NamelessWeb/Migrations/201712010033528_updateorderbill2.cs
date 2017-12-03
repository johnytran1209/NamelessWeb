namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderbill2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpBillDetails", "Product", c => c.String(nullable: false));
            DropColumn("dbo.ExpBillDetails", "Model");
            DropColumn("dbo.ExpBillDetails", "ExpEmp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExpBillDetails", "ExpEmp", c => c.String(nullable: false));
            AddColumn("dbo.ExpBillDetails", "Model", c => c.String(nullable: false));
            DropColumn("dbo.ExpBillDetails", "Product");
        }
    }
}
