using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OnlineCoupone.DAL.Repository;
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
            var repository = new Repository();
            ViewBag.PoliclinicId = policlinicId;
            ViewBag.Specializations = repository.GetAllSpecializations();
            return View();
        }

        public ActionResult OrderStep1(int policlinicId, int specializationId)
        {
            var repository = new Repository();
            ViewBag.PoliclinicId = policlinicId;
            ViewBag.SpecializationId = specializationId;
            var avalibleDoctors = repository.GetDoctorsBySpecializationId(specializationId);
            ViewBag.Doctors = avalibleDoctors;
            return View();
        }

        public ActionResult OrderStep2(int specializationId, int doctorId = -1, int policlinicId = -1)
        {
            var repository = new Repository();
            var avaliableDates = repository.GetAvailableTimesByDoctorId(doctorId).Where(t => t.Time > DateTime.Now).Select(t => t.Time);
            ViewBag.PoliclinicId = policlinicId;
            ViewBag.SpecializationId = specializationId;
            ViewBag.DoctorId = doctorId;
            ViewBag.Dates = avaliableDates.DistinctBy(t => t.Date).ToList();
            return View();
        }

        public ActionResult OrderStep3(string date, int specializationId, int doctorId = -1, int policlinicId = -1)
        {
            var repository = new Repository();
            var availableTimes = repository.GetAvailableTimesByDoctorId(doctorId).Where(t => t.Time > DateTime.Now).Select(t => t.Time);
            var toView = new Dictionary<int, List<DateTime>>();
            var res = availableTimes.GroupBy(t => t.Hour);
            foreach (var re in res)
            {
                var minutes = new List<DateTime>();
                foreach (var minute in re)
                {
                    minutes.Add(minute);
                }
                toView.Add(re.Key, minutes);
            }
            ViewBag.PoliclinicId = policlinicId;
            ViewBag.SpecializationId = specializationId;
            ViewBag.DoctorId = doctorId;
            ViewBag.Date = date;
            ViewBag.Times = toView;
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
            var repository = new Repository();
            var order = repository.GetVisitHistoryById(orderId);
            ViewBag.Order = order;
            return View();
        }

        public ActionResult HomeOrder(int policlinicId)
        {
            ViewBag.PoliclinicId = policlinicId;
            return View();
        }

        public ActionResult HomeOrderSuccess(int orderId)
        {
            ViewBag.OrderId = orderId;
            ViewBag.HomeVisitHistory = new Repository().GetHomeVisitHistoryById(orderId);
            return View();
        }
    }
}