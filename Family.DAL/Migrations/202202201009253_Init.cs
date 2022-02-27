namespace Family.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MotherId = c.Int(nullable: false),
                        FatherId = c.Int(nullable: false),
                        MarriedDate = c.DateTime(nullable: false),
                        IsMaried = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.FatherId)
                .ForeignKey("dbo.People", t => t.MotherId)
                .Index(t => t.MotherId)
                .Index(t => t.FatherId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 200),
                        LastName = c.String(),
                        BirthOfDay = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        IsLife = c.Boolean(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parents", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.FirstName, unique: true)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parents", "MotherId", "dbo.People");
            DropForeignKey("dbo.Parents", "FatherId", "dbo.People");
            DropForeignKey("dbo.People", "ParentId", "dbo.Parents");
            DropIndex("dbo.People", new[] { "ParentId" });
            DropIndex("dbo.People", new[] { "FirstName" });
            DropIndex("dbo.Parents", new[] { "FatherId" });
            DropIndex("dbo.Parents", new[] { "MotherId" });
            DropTable("dbo.People");
            DropTable("dbo.Parents");
        }
    }
}
