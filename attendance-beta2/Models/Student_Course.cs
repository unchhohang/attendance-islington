using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Student_Course
    {
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
    }
}