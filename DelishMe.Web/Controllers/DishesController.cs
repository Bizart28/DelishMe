using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DelishMe.Web.Models;
using DelishMe.Web.ViewModels;

namespace DelishMe.Web.Controllers
{
    public class DishesController : Controller
    {
        public ViewResult Index()
        {
            var dishes = GetDishes();

            return View(dishes);
        }

        private IEnumerable<Dish> GetDishes()
        {
            return new List<Dish>
            {
                new Dish { Id = 1, Name = "Мамалыга" },
                new Dish { Id = 2, Name = "Котлеты" }
            };
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