namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _default : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        RoutineId = c.Int(nullable: false),
                        PunchTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.Routines", t => t.RoutineId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.RoutineId);
            
            CreateTable(
                "dbo.Routines",
                c => new
                    {
                        RoutineId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Room = c.String(nullable: false),
                        ClassType = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoutineId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TeacherId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        Year = c.DateTime(nullable: false),
                        Level = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SemesterId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNo = c.Int(nullable: false),
                        address = c.String(nullable: false),
                        EnrollDate = c.DateTime(nullable: false),
                        FacultyId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Routine_Student",
                c => new
                    {
                        RoutineStudentID = c.Int(nullable: false, identity: true),
                        RoutineId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoutineStudentID)
                .ForeignKey("dbo.Routines", t => t.RoutineId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.RoutineId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Semester_Routine",
                c => new
                    {
                        SemesterRoutineId = c.Int(nullable: false, identity: true),
                        SemesterId = c.Int(),
                        RoutineId = c.Int(),
                    })
                .PrimaryKey(t => t.SemesterRoutineId)
                .ForeignKey("dbo.Routines", t => t.RoutineId)
                .ForeignKey("dbo.Semesters", t => t.SemesterId)
                .Index(t => t.SemesterId)
                .Index(t => t.RoutineId);
            
            CreateTable(
                "dbo.Student_Course",
                c => new
                    {
                        StudentCourseId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.teacher_course",
                c => new
                    {
                        Teacher_Course_Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Teacher_Course_Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.teacher_course", "TeacherId", "dbo.Staffs");
            DropForeignKey("dbo.teacher_course", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Student_Course", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Student_Course", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Semester_Routine", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Semester_Routine", "RoutineId", "dbo.Routines");
            DropForeignKey("dbo.Routine_Student", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Routine_Student", "RoutineId", "dbo.Routines");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Attendances", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Attendances", "RoutineId", "dbo.Routines");
            DropForeignKey("dbo.Routines", "TeacherId", "dbo.Staffs");
            DropForeignKey("dbo.Routines", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Routines", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.teacher_course", new[] { "CourseId" });
            DropIndex("dbo.teacher_course", new[] { "TeacherId" });
            DropIndex("dbo.Student_Course", new[] { "StudentId" });
            DropIndex("dbo.Student_Course", new[] { "CourseId" });
            DropIndex("dbo.Semester_Routine", new[] { "RoutineId" });
            DropIndex("dbo.Semester_Routine", new[] { "SemesterId" });
            DropIndex("dbo.Routine_Student", new[] { "StudentId" });
            DropIndex("dbo.Routine_Student", new[] { "RoutineId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Students", new[] { "FacultyId" });
            DropIndex("dbo.Courses", new[] { "FacultyId" });
            DropIndex("dbo.Routines", new[] { "SemesterId" });
            DropIndex("dbo.Routines", new[] { "TeacherId" });
            DropIndex("dbo.Routines", new[] { "CourseId" });
            DropIndex("dbo.Attendances", new[] { "RoutineId" });
            DropIndex("dbo.Attendances", new[] { "StudentId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.teacher_course");
            DropTable("dbo.Student_Course");
            DropTable("dbo.Semester_Routine");
            DropTable("dbo.Routine_Student");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Students");
            DropTable("dbo.Staffs");
            DropTable("dbo.Semesters");
            DropTable("dbo.Faculties");
            DropTable("dbo.Courses");
            DropTable("dbo.Routines");
            DropTable("dbo.Attendances");
        }
    }
}
