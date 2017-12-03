namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderbill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExportBills", "ExpEmpId", c => c.String(nullable: false));
            AddColumn("dbo.ExportBills", "ExpCusId", c => c.String(nullable: false));
            AddColumn("dbo.ExportBills", "ExpDes", c => c.String(nullable: false));
            AlterColumn("dbo.ExpBillDetails", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.ExpBillDetails", "ExpEmp", c => c.String(nullable: false));
            AlterColumn("dbo.ExportBills", "ExpEmp", c => c.String(nullable: false));
            AlterColumn("dbo.ExportBills", "ExpCus", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExportBills", "ExpCus", c => c.String());
            AlterColumn("dbo.ExportBills", "ExpEmp", c => c.String());
            AlterColumn("dbo.ExpBillDetails", "ExpEmp", c => c.String());
            AlterColumn("dbo.ExpBillDetails", "Model", c => c.String());
            DropColumn("dbo.ExportBills", "ExpDes");
            DropColumn("dbo.ExportBills", "ExpCusId");
            DropColumn("dbo.ExportBills", "ExpEmpId");
        }
    }
}
