using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DelishMe.Web.Dtos
{
    public class NewOrderDto
    {
        public int CustomerId { get; set; }
        public List<int> DishIds { get; set; }
    }
}