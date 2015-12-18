using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCoupone.Web.Models;
using OnlineCoupone.Web.Models.API;

namespace OnlineCoupone.Web.Controllers
{
    public class DoctorController : Controller
    {
        [HttpGet]
        public JsonResult GetDoctorsBySpecializationIdAndPoliclinicId(int specializationId = -1, int policlinicId = -1)
        {
            var doctors = new List<Doctor> { new Doctor { DoctorId = 1, Fio = "Иванова А.А." } };
            return Json(doctors, JsonRequestBehavior.AllowGet);
        }
	}
}