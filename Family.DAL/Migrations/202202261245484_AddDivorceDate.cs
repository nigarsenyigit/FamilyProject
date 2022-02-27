namespace Family.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDivorceDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "DivorceDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parents", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parents", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.People", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.Requests", "Relation", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "Response", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requests", "UpdatedOn", c => c.DateTime());
            DropColumn("dbo.Requests", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Requests", "UpdatedOn");
            DropColumn("dbo.Requests", "CreatedOn");
            DropColumn("dbo.Requests", "Response");
            DropColumn("dbo.Requests", "Relation");
            DropColumn("dbo.People", "UpdatedOn");
            DropColumn("dbo.People", "CreatedOn");
            DropColumn("dbo.Parents", "UpdatedOn");
            DropColumn("dbo.Parents", "CreatedOn");
            DropColumn("dbo.Parents", "DivorceDate");
        }
    }
}
