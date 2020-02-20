namespace Pomodoro_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNbPomodoro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "NbPomodoros", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sessions", "NbPomodoros");
        }
    }
}
