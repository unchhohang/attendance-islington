namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Routines", "Day", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Routines", "Day", c => c.Int(nullable: false));
        }
    }
}
