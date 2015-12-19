using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCoupone.DAL.Repository;

namespace OnlineCoupone.Web.Controllers
{
    public class MyTalonController : Controller
    {
        //
        // GET: /MyTalon/
        public ActionResult Index(int policlinicId)
        {
            ViewBag.PoliclinicId = policlinicId;
            return View();
        }

        public ActionResult History(int policlinicId, int patientId)
        {
            var repository = new Repository();
            var histories = repository.GetAllVisitsByPateientIdAndPoliclinicId(patientId, policlinicId);
            ViewBag.PoliclinicId = policlinicId;
            ViewBag.PatientId = patientId;
            ViewBag.Histories = histories;
            return View();
        }

        public ActionResult HomeVisitHistory(int policlinicId, int patientId)
        {
            var repository = new Repository();
            var homeVisitHistories = repository.GetHomeVisitHistoriesByPatientIdAndPoliclinicId(policlinicId, patientId);
            ViewBag.PoliclinicId = policlinicId;
            ViewBag.PatientId = patientId;
            ViewBag.Histories = homeVisitHistories;
            return View();
        }

        public ActionResult CancelOrder(int policlinicId, int patientId, int visitHistoryId)
        {
            var repository = new Repository();
            var history = repository.GetVisitHistoryById(visitHistoryId);
            repository.SetUnusedAvailableTimeById(history.AvailableTime.AvailableTimeId);
            repository.DeleteVisitHistory(visitHistoryId);
            return RedirectToAction("History", new {policlinicId = policlinicId, patientId = patientId});
        }

        public ActionResult CancelHomeOrder(int policlinicId, int patientId, int homeVisitHistoryId)
        {
            var repository = new Repository();
            repository.DeleteHomeVisitHistory(homeVisitHistoryId);
            return RedirectToAction("HomeVisitHistory", new {policlinicId = policlinicId, patientId = patientId});
        }

	}
}