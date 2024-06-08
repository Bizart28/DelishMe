using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DelishMe.Web.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Dish Dish { get; set; }

        public DateTime DateOrdered { get; set; }

        public DateTime? DateFinished { get; set; }
    }
}