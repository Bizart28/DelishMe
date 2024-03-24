using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DelishMe.Web.Models;

namespace DelishMe.Web.Controllers
{
    public class DishesController : Controller
    {
        // GET: Dishes
        public ActionResult Random()
        {
            var dish = new Dish() { Name = "Мамалыга" };
            return View(dish);
        }
    }
}