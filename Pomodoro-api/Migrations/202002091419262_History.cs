namespace Pomodoro_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class History : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Histories", "TagId", "dbo.Tags");
            DropIndex("dbo.Histories", new[] { "TagId" });
            DropTable("dbo.Histories");
        }
    }
}
