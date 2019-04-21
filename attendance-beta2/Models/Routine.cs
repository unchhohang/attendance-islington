using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Routine
    {
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
        public int ClassType { get; set; }
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
        
    }
}