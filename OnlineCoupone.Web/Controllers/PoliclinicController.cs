using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCoupone.DAL.Repository;

namespace OnlineCoupone.Web.Controllers
{
    public class PoliclinicController : Controller
    {
        //
        // GET: /Policlinic/
        public ActionResult Index(int policlinicId)
        {
            ViewBag.PoliclinicId = policlinicId;
            var repository = new Repository();
            ViewBag.Policlinic = repository.GetPoliclinicById(policlinicId);
            return View();
        }
	}
}