using System;
using System.Web.Mvc;
using OnlineCoupone.DAL.Repository;
using OnlineCoupone.Model.ModelDB;

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
            if (!repository.SetUsedAvailableTimeByTime(DateTime.Parse(date + " " + time), result))
            {
                return -1;
            }
            var availableTime = repository.GetAvailableTimeByTime(DateTime.Parse(date + " " + time));
            return availableTime != null ? repository.AddOrder(result, doctorId, availableTime.AvailableTimeId) : -1;
        }

        [HttpPost]
        public int ValidateUser(Patient patient)
        {
            var repository = new Repository();
            return repository.IsPatientExists(patient);
        }

        public int ValidateHomeOrder(Patient patient, string date, int policlinicId)
        {
            var repository = new Repository();
            var result = repository.IsPatientExists(patient);
            if (result == -1)
            {
                return -1;
            }
            return repository.AddHomeVisitHistory(new HomeVisitHistory()
            {
                Date = DateTime.Parse(date),
                Policlinic = repository.GetPoliclinicById(policlinicId),
                Patient = patient
            });
        }
	}
}