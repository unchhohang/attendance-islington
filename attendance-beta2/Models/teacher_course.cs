using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class teacher_course
    {
        [Key]
        public int Teacher_Course_Id { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int CourseId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Staff Teachers { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Courses{ get; set; }

    }
}