using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCoupone.DAL.Repository;
using OnlineCoupone.Model.ModelDB;
using OnlineCoupone.Web.Models;

namespace OnlineCoupone.Web.Controllers
{
    public class ValidateController : Controller
    {
        [HttpPost]
        public int ValidateOrder(Patient patient, int doctorId, string date, string time)
        {
            var repository = new Repository();
            var result = repository.IsPatientExists(patient);
            if (result == -1)
            {
                return -1;
            }
            var availableTime = repository.GetAvailableTimeByTime(DateTime.Parse(date + " " + time));
            return availableTime != null ? repository.AddOrder(result, doctorId, availableTime.AvailableTimeId) : -1;
        }
	}
}