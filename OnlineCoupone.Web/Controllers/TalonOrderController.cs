using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCoupone.Web.Models;

namespace OnlineCoupone.Web.Controllers
{
    public class TalonOrderController : Controller
    {
        //
        // GET: /TalonOrder/
        public ActionResult Index(int policlinicId)
        {
            ViewBag.PoliclinicId = policlinicId;
            return View();
        }

        

        public ActionResult OrderStep2(int doctorId = -1, int policlinicId = -1)
        {
            var avaliableDates = new List<DateTime>()
            {
                new DateTime(2015, 10, 23, 18, 40, 0),
                new DateTime(2015, 10, 23, 19, 0, 0)
            };
            ViewBag.Dates = avaliableDates;
            return View();
        }

        public ActionResult OrderStep3(string date)
        {
            var availableTimes = new List<string>()
            {
                new DateTime(2015, 10, 10, 14, 10, 0).ToShortTimeString(),
                new DateTime(2015, 10, 10, 14, 30, 0).ToShortTimeString()
            };
            ViewBag.Times = availableTimes;
            return View();
        }

	}
}