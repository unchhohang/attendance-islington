using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Course
    {
        List<Course> list = new List<Course>();
        public List<Course> List(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Course cour = new Course();
                cour.CourseId = Convert.ToInt32(dt.Rows[i]["courseId"]);
                cour.Name = dt.Rows[i]["Name"].ToString();
                cour.FacultyId = Convert.ToInt32(dt.Rows[i][FacultyId]);
                cour.FacultyName = dt.Rows[i]["FacultyName"].ToString();
                
                list.Add(cour);
            }
            return list;

        }
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int FacultyId { get; set; }


       [ForeignKey("FacultyId")]
       public virtual Faculty Faculties { get; set; }
       [NotMapped]
       public string FacultyName { get; set; }
    }
}