namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpBillDetails",
                c => new
                    {
                        ExpBId = c.String(nullable: false, maxLength: 128),
                        Model = c.String(),
                        Qtt = c.Int(nullable: false),
                        Cost = c.Single(nullable: false),
                        ExpEmp = c.String(),
                    })
                .PrimaryKey(t => t.ExpBId);
            
            CreateTable(
                "dbo.ExportBills",
                c => new
                    {
                        ExpBId = c.String(nullable: false, maxLength: 128),
                        ExpDate = c.DateTime(nullable: false),
                        ExpEmp = c.String(),
                        ExpCus = c.String(),
                    })
                .PrimaryKey(t => t.ExpBId);
            
            CreateTable(
                "dbo.ImpBillDetails",
                c => new
                    {
                        ImpBId = c.String(nullable: false, maxLength: 128),
                        Model = c.String(),
                        Qtt = c.Int(nullable: false),
                        ImpCost = c.Single(nullable: false),
                        ImpEmp = c.String(),
                    })
                .PrimaryKey(t => t.ImpBId);
            
            CreateTable(
                "dbo.ImportBills",
                c => new
                    {
                        ImpBId = c.String(nullable: false, maxLength: 128),
                        ImpDate = c.DateTime(nullable: false),
                        ImpEmp = c.String(),
                        NoteId = c.String(),
                    })
                .PrimaryKey(t => t.ImpBId);
            
            CreateTable(
                "dbo.OrdBillDetails",
                c => new
                    {
                        OrdBId = c.String(nullable: false, maxLength: 128),
                        Model = c.String(),
                        Qtt = c.Int(nullable: false),
                        OrdCost = c.Single(nullable: false),
                        OrdEmp = c.String(),
                    })
                .PrimaryKey(t => t.OrdBId);
            
            CreateTable(
                "dbo.OrderBills",
                c => new
                    {
                        OrdBId = c.String(nullable: false, maxLength: 128),
                        OrdDate = c.DateTime(nullable: false),
                        OrdEmp = c.String(),
                    })
                .PrimaryKey(t => t.OrdBId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderBills");
            DropTable("dbo.OrdBillDetails");
            DropTable("dbo.ImportBills");
            DropTable("dbo.ImpBillDetails");
            DropTable("dbo.ExportBills");
            DropTable("dbo.ExpBillDetails");
        }
    }
}
