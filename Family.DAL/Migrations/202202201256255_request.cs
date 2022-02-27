namespace Family.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class request : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.ReceiverId)
                .ForeignKey("dbo.People", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "SenderId", "dbo.People");
            DropForeignKey("dbo.Requests", "ReceiverId", "dbo.People");
            DropIndex("dbo.Requests", new[] { "ReceiverId" });
            DropIndex("dbo.Requests", new[] { "SenderId" });
            DropTable("dbo.Requests");
        }
    }
}
