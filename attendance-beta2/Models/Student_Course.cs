using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Student_Course
    {
        List<Student_Course> list = new List<Student_Course>();
        public Student_Course() { }
        public List<Student_Course> List(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student_Course stdCour = new Student_Course();
                stdCour.StudentCourseId = Convert.ToInt32(dt.Rows[i]["StudentCourseId"]);
                stdCour.CourseId = Convert.ToInt32(dt.Rows[i]["CourseId"].ToString());
                stdCour.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"].ToString());
                stdCour.StudentName = dt.Rows[i]["StudentName"].ToString();
                stdCour.CourseName = dt.Rows[i]["Name"].ToString();
                
                list.Add(stdCour);
            }
            return list;

        }
        [Key]
        public int StudentCourseId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Courses { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Students { get; set; }

        [NotMapped]
        public string StudentName { get; set; }
        public string CourseName { get; set; }
    }
}