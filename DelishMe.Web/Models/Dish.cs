using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DelishMe.Web.Models
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set;}
        public string Description { get; set;}
        [Required]
        public Category Category { get; set; }
        public byte CategoryId { get; set; }  
        public DateTime DateAdded { get; set; }
        public string ImagePath { get; set; }
    }
}