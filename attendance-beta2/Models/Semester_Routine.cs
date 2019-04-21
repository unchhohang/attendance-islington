using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Semester_Routine
    {
        [Key]
        public int SemesterRoutineId { get; set; }
        
        public int? SemesterId { get; set; }
        public int? RoutineId { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester Semesters {get; set;}
        [ForeignKey("RoutineId")]
        public virtual Routine Routines { get; set; }
    }
}