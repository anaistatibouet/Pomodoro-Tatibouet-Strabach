namespace Pomodoro_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagNullableInPomodoro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pomodoroes", "TagId", "dbo.Tags");
            DropIndex("dbo.Pomodoroes", new[] { "TagId" });
            AlterColumn("dbo.Pomodoroes", "TagId", c => c.Int());
            CreateIndex("dbo.Pomodoroes", "TagId");
            AddForeignKey("dbo.Pomodoroes", "TagId", "dbo.Tags", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pomodoroes", "TagId", "dbo.Tags");
            DropIndex("dbo.Pomodoroes", new[] { "TagId" });
            AlterColumn("dbo.Pomodoroes", "TagId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pomodoroes", "TagId");
            AddForeignKey("dbo.Pomodoroes", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}
