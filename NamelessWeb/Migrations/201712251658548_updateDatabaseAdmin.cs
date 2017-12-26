namespace NamelessWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabaseAdmin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BangPhanCongCongViecs", "thoigian", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BangPhanCongCongViecs", "thoigian", c => c.DateTime(nullable: false));
        }
    }
}
