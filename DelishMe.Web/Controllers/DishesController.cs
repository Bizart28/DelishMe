using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DelishMe.Web.Models;
using DelishMe.Web.ViewModels;
using System.Data.Entity;


namespace DelishMe.Web.Controllers
{
    public class DishesController : Controller
    {
        private ApplicationDbContext _context;

        public DishesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var dishes = _context.Dishes.Include(m => m.Category).ToList();

            return View(dishes);
        }

        public ActionResult Details(int id)
        {
           
            var dish = _context.Dishes.Include(m => m.Category).SingleOrDefault(m => m.Id == id);

            if (dish == null)
                return HttpNotFound();

            return View(dish);

        }


        // GET: Dishes
        public ActionResult Random()
        {
            var dish = new Dish() { Name = "Мамалыга"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer1"},
                new Customer {Name = "Customer2"}
            };
            var viewModel = new RandomDishViewModel
            {
                Dish = dish,
                Customers = customers
            };
            return View(viewModel);
        }
    }
}