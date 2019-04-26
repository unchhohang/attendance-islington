namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "Attended", c => c.Int(nullable: false));
            DropColumn("dbo.Attendances", "PunchTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "PunchTime", c => c.String(nullable: false));
            DropColumn("dbo.Attendances", "Attended");
        }
    }
}
