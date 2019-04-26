using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Routine
    {
        List<Routine> list = new List<Routine>();
        public Routine() { }
        public List<Routine> List(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Routine r = new Routine();
                r.RoutineId = Convert.ToInt32(dt.Rows[i]["RoutineId"]);
                r.CourseId = Convert.ToInt32(dt.Rows[i]["CourseId"]);
                r.Day = ((DayOfWeek)(dt.Rows[i]["Day"]));
                r.StartTime = DateTime.Parse(dt.Rows[i]["StartTime"].ToString());
                r.EndTime = DateTime.Parse(dt.Rows[i]["EndTime"].ToString());
                r.Room = dt.Rows[i]["Room"].ToString();
                r.ClassType = dt.Rows[i]["ClassType"].ToString();
                r.TeacherId = Convert.ToInt32(dt.Rows[i]["TeacherId"].ToString());
                r.SemesterId = Convert.ToInt32(dt.Rows[i]["SemesterId"].ToString());
                if (dt.Columns.Contains("CourseName"))
                {
                    r.CourseName = dt.Rows[i]["CourseName"].ToString();
                }
                if (dt.Columns.Contains("TeacherName"))
                {
                    r.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                }
                if (dt.Columns.Contains("SemesterLevel"))
                {
                    r.SemesterLevel = dt.Rows[i]["SemesterLevel"].ToString();

                }
                list.Add(r);
            }
            return list;

        }

        [Key]
        public int RoutineId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public DayOfWeek Day { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public string Room { get; set; }
        [Required]
        public String ClassType { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int SemesterId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Courses { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Staff Teachers { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester Semesters { get; set; }

        [NotMapped]
        public string CourseName { get; set; }
        [NotMapped]
        public string TeacherName { get; set; }
        [NotMapped]
        public string SemesterLevel { get; set; }
        [NotMapped]
        public string DayName { get; set; }



    }
}