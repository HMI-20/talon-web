using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCoupone.DAL.Repository;

namespace OnlineCoupone.Web.Controllers
{
    public class RegionController : Controller
    {
        public ActionResult Index(int regionId)
        {
            ViewBag.RegionId = regionId;
            var repository = new Repository();
            ViewBag.Policlinics = repository.GetPoliclinicsByRegionId(regionId);
            return View();
        }
	}
}