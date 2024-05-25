﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DelishMe.Web.Dtos;
using DelishMe.Web.Models;
using Microsoft.Owin.Security.OAuth;

namespace DelishMe.Web.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController() {
            _context = new ApplicationDbContext();
            }
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if(customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges(); 
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateCusomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
                return NotFound();
            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id) {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
