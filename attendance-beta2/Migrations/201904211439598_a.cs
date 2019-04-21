namespace attendance_beta2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faculties", "Faculty_FacultyId", c => c.Int());
            CreateIndex("dbo.Faculties", "Faculty_FacultyId");
            AddForeignKey("dbo.Faculties", "Faculty_FacultyId", "dbo.Faculties", "FacultyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Faculties", "Faculty_FacultyId", "dbo.Faculties");
            DropIndex("dbo.Faculties", new[] { "Faculty_FacultyId" });
            DropColumn("dbo.Faculties", "Faculty_FacultyId");
        }
    }
}
