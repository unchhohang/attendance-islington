namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student_Course", "CourseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student_Course", "CourseName");
        }
    }
}
