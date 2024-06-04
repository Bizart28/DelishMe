using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DelishMe.Web.Models;

namespace DelishMe.Web.Dtos
{
    public class DishDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte CategoryId { get; set; }
        public CategoryDto Category { get; set; }  
        public DateTime DateAdded { get; set; }
        public string ImagePath { get; set; }
    }
}