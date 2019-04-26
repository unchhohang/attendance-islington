namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "PunchTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "PunchTime", c => c.DateTime(nullable: false));
        }
    }
}
