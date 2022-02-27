namespace Family.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parentIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "ParentId", "dbo.Parents");
            DropIndex("dbo.People", new[] { "ParentId" });
            AlterColumn("dbo.People", "ParentId", c => c.Int());
            CreateIndex("dbo.People", "ParentId");
            AddForeignKey("dbo.People", "ParentId", "dbo.Parents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "ParentId", "dbo.Parents");
            DropIndex("dbo.People", new[] { "ParentId" });
            AlterColumn("dbo.People", "ParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "ParentId");
            AddForeignKey("dbo.People", "ParentId", "dbo.Parents", "Id", cascadeDelete: true);
        }
    }
}
