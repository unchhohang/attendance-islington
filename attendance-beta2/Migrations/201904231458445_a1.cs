namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.teacher_course", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.teacher_course", "TeacherId", "dbo.Staffs");
            DropIndex("dbo.teacher_course", new[] { "TeacherId" });
            DropIndex("dbo.teacher_course", new[] { "CourseId" });
            DropTable("dbo.teacher_course");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.teacher_course",
                c => new
                    {
                        Teacher_Course_Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Teacher_Course_Id);
            
            CreateIndex("dbo.teacher_course", "CourseId");
            CreateIndex("dbo.teacher_course", "TeacherId");
            AddForeignKey("dbo.teacher_course", "TeacherId", "dbo.Staffs", "StaffId", cascadeDelete: true);
            AddForeignKey("dbo.teacher_course", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}
