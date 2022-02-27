namespace Family.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class signInfo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.People", new[] { "FirstName" });
            AddColumn("dbo.People", "UserName", c => c.String());
            AddColumn("dbo.People", "Password", c => c.String());
            AlterColumn("dbo.People", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "FirstName", c => c.String(maxLength: 200));
            DropColumn("dbo.People", "Password");
            DropColumn("dbo.People", "UserName");
            CreateIndex("dbo.People", "FirstName", unique: true);
        }
    }
}
