namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Attendances", "attended");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "attended", c => c.Int(nullable: false));
        }
    }
}
