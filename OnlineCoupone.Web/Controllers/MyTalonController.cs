using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoupone.Web.Controllers
{
    public class MyTalonController : Controller
    {
        //
        // GET: /MyTalon/
        public ActionResult Index(int policlinicId)
        {
            return View();
        }

	}
}