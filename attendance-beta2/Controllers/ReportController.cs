using attendance_beta2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace attendance_beta2.Controllers
{
    public class ReportController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Report
        public ActionResult DailyReport()
        {
            string sql = "SELECT A.*, S.StudentName FROM Attendances A JOIN Students S ON S.StudentId = A.StudentId ";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Report().GetReport(dt);
            
            //ViewBag.Date = new SelectList(db.Attendances, );
            return View();
        }
        //Post:Report
        public ActionResult DailyReport(Attendance attendance)
        {
            string sql = "SELECT A.*, S.StudentName FROM Attendances A JOIN Students S ON S.StudentId = A.StudentId " +
                "Whhere A.puchTime = " + attendance.punchTime;
            return View();
        }

        public ActionResult weeklyReport()
        {

            return View();
        }

        public ActionResult monthlyReport()
        {

            return View();
        }
    }


}