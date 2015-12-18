using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCoupone.Web.Models;
using OnlineCoupone.Web.Models.API;

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

        public ActionResult OrderStep1(int policlinicId, int specializationId)
        {
            ViewBag.PoliclinicId = policlinicId;
            ViewBag.SpecializationId = specializationId;
            var avalibleDoctors = new List<Doctor>()
            {
                new Doctor() {DoctorId = 1, Fio = "Ivanova"},
                new Doctor() {DoctorId = 2, Fio = "Petrova"},
            };
            ViewBag.Doctors = avalibleDoctors;
            return View();
        }

        public ActionResult OrderStep2(int specializationId, int doctorId = -1, int policlinicId = -1)
        {
            var avaliableDates = new List<DateTime>()
            {
                new DateTime(2015, 10, 23, 18, 40, 0),
                new DateTime(2015, 10, 23, 19, 0, 0)
            };
            ViewBag.PoliclinicId = policlinicId;
            ViewBag.SpecializationId = specializationId;
            ViewBag.DoctorId = doctorId;
            ViewBag.Dates = avaliableDates;
            return View();
        }

        public ActionResult OrderStep3(string date, int specializationId, int doctorId = -1, int policlinicId = -1)
        {
            var availableTimes = new List<string>()
            {
                new DateTime(2015, 10, 10, 14, 10, 0).ToShortTimeString(),
                new DateTime(2015, 10, 10, 14, 30, 0).ToShortTimeString()
            };
            ViewBag.PoliclinicId = policlinicId;
            ViewBag.SpecializationId = specializationId;
            ViewBag.DoctorId = doctorId;
            ViewBag.Date = date;
            ViewBag.Times = availableTimes;
            return View();
        }

        public ActionResult OrderStep4(string time, string date, int specializationId, int doctorId = -1, int policlinicId = -1)
        {
            ViewBag.PoliclinicId = policlinicId;
            ViewBag.SpecializationId = specializationId;
            ViewBag.DoctorId = doctorId;
            ViewBag.Date = date;
            ViewBag.Time = time;
            return View();
        }

        public ActionResult OrderStep5(int orderId)
        {
            return View();
        }

    }
}