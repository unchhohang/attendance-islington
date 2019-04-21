using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public String StudentName { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public int ContactNo { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public DateTime EnrollDate { get; set; }
        
        public int? FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculties { get; set;}
    }

    
}