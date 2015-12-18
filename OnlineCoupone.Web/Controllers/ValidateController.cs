using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCoupone.Web.Models;

namespace OnlineCoupone.Web.Controllers
{
    public class ValidateController : Controller
    {
        [HttpPost]
        public int ValidateOrder(Order order)
        {
            return 1;
        }
	}
}