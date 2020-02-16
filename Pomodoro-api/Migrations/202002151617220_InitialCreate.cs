namespace Pomodoro_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pomodoroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        SessionId = c.Int(nullable: false),
                        TagId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId)
                .Index(t => t.SessionId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pomodoroes", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Pomodoroes", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Histories", "TagId", "dbo.Tags");
            DropIndex("dbo.Pomodoroes", new[] { "TagId" });
            DropIndex("dbo.Pomodoroes", new[] { "SessionId" });
            DropIndex("dbo.Histories", new[] { "TagId" });
            DropTable("dbo.Sessions");
            DropTable("dbo.Pomodoroes");
            DropTable("dbo.Tags");
            DropTable("dbo.Histories");
        }
    }
}
