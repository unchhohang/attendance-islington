namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Staffs", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "Type", c => c.Int(nullable: false));
        }
    }
}
