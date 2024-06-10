using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DelishMe.Web.Models;

namespace DelishMe.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var topDishes = _context.Dishes
                                      .OrderByDescending(d => d.DateAdded)
                                      .Take(3)
                                      .ToList();
            return View(topDishes);
        }

        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult Privacy()
        {
            return View();
        }
    }
}