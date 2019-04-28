using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Attendance
    {
        List<Attendance> list = new List<Attendance>();
        public Attendance() { }
        public List<Attendance> List(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Attendance at = new Attendance();
                //at.AttendanceId = Convert.ToInt32(dt.Rows[i]["AttendanceId"].ToString());
                //at.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"].ToString());
                //at.StudentName = dt.Rows[i]["StudentName"].ToString();
                //at.RoutineId = Convert.ToInt32(dt.Rows[i]["RoutineId"].ToString());
                //at.punchTime = DateTime.Parse(dt.Rows[i]["RoutineId"].ToString());
                //at.Present = Convert.ToInt32(dt.Rows[i]["Presesnt"].ToString());

                at.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"].ToString());
                at.StudentName = dt.Rows[i]["StudentName"].ToString();

                list.Add(at);
            }
            return list;

        }
        [Key]
        public int AttendanceId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int RoutineId { get; set; }
        [Required]
        public string Present { get; set; }
        
        
        public DateTime punchTime { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Students { get; set; }

        [ForeignKey("RoutineId")]
        public virtual Routine Routines { get; set; }

        [NotMapped]
        public String StudentName { get; set; }
        [NotMapped]
        public Status Attended { get; set; }

        [NotMapped]
        public String CourseName { get; set; }
        [NotMapped]
        public String TeacherName { get; set; }
        [NotMapped]
        public String SemesterLevel { get; set; }
        

    }
    
    public enum Status
    {
        Present =1,
        Absent = 0,
        Late = 2
    }
}