using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DelishMe.Web.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult New()
        {
            return View();
        }
    }
}