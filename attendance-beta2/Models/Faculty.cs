using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace attendance_beta2.Models
{
    public class Faculty
    {
        List<Faculty> list = new List<Faculty>();
        public Faculty() { }
        public List<Faculty> List(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Faculty fac = new Faculty();
                fac.FacultyId = Convert.ToInt32(dt.Rows[i]["FacultyId"]);
                fac.FacultyName = dt.Rows[i]["FacultyName"].ToString();
                fac.Description = dt.Rows[i]["Description"].ToString();
                list.Add(fac);
            }
            return list;

        }
        [Key]
        public int FacultyId { get; set; }
        [Required]
        public string FacultyName { get; set; }
        [Required]
        public string Description { get; set; }
        
        public List<Faculty> Faculties { get; set; }


    }
}