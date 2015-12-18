using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCoupone.Web.Models;
using OnlineCoupone.Web.Models.API;

namespace OnlineCoupone.Web.Controllers
{
    public class TalonController : Controller
    {
        [HttpGet]
        public JsonResult GetTalonsByDoctorId(int doctorId = -1)
        {
            var talons = new List<Talon>
            {
                new Talon()
                {
                    TalonId = 1,
                    Doctor = new Doctor {DoctorId = 1, Fio = "Иванова А.А."},
                    Date = DateTime.Parse("23.10.2015 14:40:00"),
                    DateToShow = "23.10.2015",
                    TimeToShow = "14:40"
                }
            };
            return Json(talons, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTalonsByDate(string date)
        {
            var dateTime = DateTime.Parse(date);
            var talons = new List<Talon>
            {
                new Talon
                {
                    TalonId = 1,
                    Doctor = new Doctor {DoctorId = 1, Fio = "Иванова А.А."},
                    Date = DateTime.Parse("23.10.2015 14:40:00"),
                    DateToShow = "23.10.2015",
                    TimeToShow = "14:40"
                }
            };
            return Json(talons, JsonRequestBehavior.AllowGet);
        }
	}
}