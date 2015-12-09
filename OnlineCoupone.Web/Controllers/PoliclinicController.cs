using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoupone.Web.Controllers
{
    public class PoliclinicController : Controller
    {
        //
        // GET: /Policlinic/
        public ActionResult Index(int policlinicId)
        {
            ViewBag.PoliclinicId = policlinicId;
            return View();
        }
	}
}