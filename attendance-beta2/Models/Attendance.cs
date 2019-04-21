using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int RoutineId { get; set; }
        [Required]
        public DateTime PunchTime { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Students { get; set; }

        [ForeignKey("RoutineId")]
        public virtual Routine Routines { get; set; }

    }
}