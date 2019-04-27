using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace attendance_beta2.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult dailyReport()
        {
            string sql = "";
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