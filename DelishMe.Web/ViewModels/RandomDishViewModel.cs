using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DelishMe.Web.Models;

namespace DelishMe.Web.ViewModels
{
    public class RandomDishViewModel
    {
        public Dish Dish { get; set; }
        public List<Customer> Customers { get; set; }
    }
}