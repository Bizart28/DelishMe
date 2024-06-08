using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DelishMe.Web.Models;
using DelishMe.Web.Dtos;

namespace DelishMe.Web.Controllers.Api
{
    public class NewOrdersController : ApiController
    {
        private ApplicationDbContext _context;

        public NewOrdersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewOrders(NewOrderDto newOrder)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newOrder.CustomerId);

            var dishes = _context.Dishes.Where(
                m => newOrder.DishIds.Contains(m.Id)).ToList();

            foreach (var dish in dishes)
            {
                
                var order = new Order
                {
                    Customer = customer,
                    Dish = dish,
                    DateOrdered = DateTime.Now
                };

                _context.Orders.Add(order);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
