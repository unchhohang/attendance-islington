namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "Present", c => c.String(nullable: false));
            DropColumn("dbo.Attendances", "Attended");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "Attended", c => c.Int(nullable: false));
            DropColumn("dbo.Attendances", "Present");
        }
    }
}
