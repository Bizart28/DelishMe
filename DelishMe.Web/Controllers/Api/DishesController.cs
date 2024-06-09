using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DelishMe.Web.Dtos;
using System.Data.Entity;
using DelishMe.Web.Models;

namespace DelishMe.Web.Controllers.Api
{
    public class DishesController : ApiController
    {
        private ApplicationDbContext _context;

        public DishesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<DishDto> GetDishes(string query = null)
        {
            var dishesQuery = _context.Dishes
                 .Include(m => m.Category);

            if (!String.IsNullOrWhiteSpace(query))
                dishesQuery = dishesQuery.Where(m => m.Name.Contains(query));

            return dishesQuery
                .ToList()
                .Select(Mapper.Map<Dish, DishDto>);
        }

        public IHttpActionResult GetDish(int id)
        {
            var dish = _context.Dishes.SingleOrDefault(c => c.Id == id);

            if (dish == null)
                return NotFound();

            return Ok(Mapper.Map<Dish, DishDto>(dish));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageDishes)]
        public IHttpActionResult CreateDish(DishDto dishDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dish = Mapper.Map<DishDto, Dish>(dishDto);
            _context.Dishes.Add(dish);
            _context.SaveChanges();

            dishDto.Id = dish.Id;
            return Created(new Uri(Request.RequestUri + "/" + dish.Id), dishDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageDishes)]
        public IHttpActionResult UpdateDish(int id, DishDto dishDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dishInDb = _context.Dishes.SingleOrDefault(c => c.Id == id);

            if (dishInDb == null)
                return NotFound();

            Mapper.Map(dishDto, dishInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageDishes)]
        public IHttpActionResult DeleteDish(int id)
        {
            var dishInDb = _context.Dishes.SingleOrDefault(c => c.Id == id);

            if (dishInDb == null)
                return NotFound();

            _context.Dishes.Remove(dishInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
