namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "Present", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "Present", c => c.String(nullable: false));
        }
    }
}
