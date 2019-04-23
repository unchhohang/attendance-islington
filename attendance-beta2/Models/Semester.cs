using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Semester
    {
        List<Semester> list = new List<Semester>();
        public Semester() { }
        public List<Semester> List(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Semester sem = new Semester();
                sem.SemesterId = Convert.ToInt32(dt.Rows[i]["SemesterId"]);
                sem.Year= dt.Rows[i]["Year"].ToString();
                sem.Level= dt.Rows[i]["Level"].ToString();
                list.Add(sem);
            }
            return list;

        }

        [Key]
        public int SemesterId { get; set; }
        [Required]
        public string Year{ get; set; }
        [Required]
        public String Level{ get; set; }

    }
}