using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoupone.Web.Controllers
{
    public class RegionController : Controller
    {
        public ActionResult Index(int regionId)
        {
            ViewBag.RegionId = regionId;
            return View();
        }
	}
}