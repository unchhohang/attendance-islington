using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Student
    {
        List<Student> list = new List<Student>();
        public Student() { }
        public List<Student> List(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student std = new Student();
                std.StudentId= Convert.ToInt32(dt.Rows[i]["StudentId"]);
                std.StudentName = dt.Rows[i]["StudentName"].ToString();
                std.Email = dt.Rows[i]["Email"].ToString();
                std.ContactNo = dt.Rows[i]["ContactNo"].ToString();
                std.address = dt.Rows[i]["address"].ToString();
                std.EnrollDate = DateTime.Parse(dt.Rows[i]["EnrollDate"].ToString());
                list.Add(std);
            }
            return list;

        }
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public DateTime EnrollDate { get; set; }
        
        
    }

    
}