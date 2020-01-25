namespace Pomodoro_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pomodoroes", "TagId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pomodoroes", "TagId");
            AddForeignKey("dbo.Pomodoroes", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pomodoroes", "TagId", "dbo.Tags");
            DropIndex("dbo.Pomodoroes", new[] { "TagId" });
            DropColumn("dbo.Pomodoroes", "TagId");
            DropTable("dbo.Tags");
        }
    }
}
