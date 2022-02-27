namespace Family.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parents", "DivorceDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parents", "DivorceDate", c => c.DateTime(nullable: false));
        }
    }
}
