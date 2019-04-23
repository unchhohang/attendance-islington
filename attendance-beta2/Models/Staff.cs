using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Staff
    {
        List<Staff> list = new List<Staff>();
        public Staff() { }
        public List<Staff> List(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Staff staff = new Staff();
                staff.StaffId = Convert.ToInt32(dt.Rows[i]["StaffId"]);
                staff.Name = dt.Rows[i]["Name"].ToString();
                staff.Contact = dt.Rows[i]["Contact"].ToString();
                staff.Address = dt.Rows[i]["Address"].ToString();
                staff.Email = dt.Rows[i]["Address"].ToString();
                
                list.Add(staff);
            }
            return list;

        }
        [Key]
        public int StaffId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        
        

    }
}