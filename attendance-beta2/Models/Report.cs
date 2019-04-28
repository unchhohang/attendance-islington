using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class Report
    {
        public List<Report> report = new List<Report>();
        public List<Report> GetReport(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Report re = new Report();
                re.AttendanceId= Convert.ToInt32(dt.Rows[i]["AttendanceId"]);
                re.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"].ToString());
                re.RoutineId = Convert.ToInt32(dt.Rows[i]["RoutineId"]);
                re.punchTime= DateTime.Parse(dt.Rows[i]["punchTime"].ToString());
                re.StudentName = dt.Rows[i]["StudentName"].ToString();
                
                re.Present = dt.Rows[i]["Present"].ToString();
                report.Add(re);
            }
            return report;
        }
        [NotMapped]
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int RoutineId { get; set; }
        [NotMapped]
        public DateTime punchTime { get; set; }
        [NotMapped]
        public string Present { get; set; }
        public string StudentName { get; set; }
        [NotMapped]
        public DateTime CompareDate { get; set; }

    }
}