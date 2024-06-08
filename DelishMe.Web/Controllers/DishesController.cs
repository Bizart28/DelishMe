using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DelishMe.Web.Models;
using DelishMe.Web.ViewModels;
using DelishMe.Web.Migrations;
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
            if (User.IsInRole("CanManageDishes")) return View("List");
            else return View("ReadOnlyList");

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

        [Authorize(Roles = RoleName.CanManageDishes)]
        public ViewResult New()
        {
            var categories = _context.Categories.ToList();

            var viewModel = new DishFormViewModel
            {
                Categories = categories
            };

            return View("DishForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageDishes)]
        public ActionResult Edit(int id)
        {
            var dish = _context.Dishes.SingleOrDefault(c => c.Id == id);

            if (dish == null)
                return HttpNotFound();

            var viewModel = new DishFormViewModel(dish)
            {
                Categories = _context.Categories.ToList(),
            };
          

            return View("DishForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageDishes)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Dish dish)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DishFormViewModel(dish)
                {
                    Categories = _context.Categories.ToList()
                };

                return View("DishForm", viewModel);
            }
            if (dish.Id == 0)
            {
                dish.DateAdded = DateTime.Now;
                _context.Dishes.Add(dish);
            }
            else
            {
                var dishInDb = _context.Dishes.Single(m => m.Id == dish.Id);
                dishInDb.Name = dish.Name;
                dishInDb.CategoryId = dish.CategoryId;
                dishInDb.Description = dish.Description;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Dishes");
        }

    }
}