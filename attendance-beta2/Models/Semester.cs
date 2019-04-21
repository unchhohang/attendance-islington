using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }
        [Required]
        public DateTime Year{ get; set; }
        [Required]
        public String Level{ get; set; }

    }
}