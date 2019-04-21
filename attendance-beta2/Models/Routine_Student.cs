using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Routine_Student
    {
        [Key]
        public int RoutineStudentID { get; set; }
        [Required]
        public int RoutineId { get; set; }
        
        [Required]
        public int StudentId {get; set;}

        [ForeignKey("RoutineId")]
        public Routine Routines { get; set; }
        [ForeignKey("StudentId")]
        public Student Students { get; set; }
    }
}