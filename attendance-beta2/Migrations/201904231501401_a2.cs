namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Routines", "ClassType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Routines", "ClassType", c => c.Int(nullable: false));
        }
    }
}
