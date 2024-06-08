using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DelishMe.Web.Models;

namespace DelishMe.Web.ViewModels
{
    public class DishFormViewModel
    
        {
        public IEnumerable<Category> Categories { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }    

        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Display(Name = "Category")]
        [Required]
        public byte? CategoryId { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Dish" : "New Dish";
            }
        }
        public DishFormViewModel()
        {
            Id = 0;
        }

        public DishFormViewModel(Dish dish)
        {
            Id = dish.Id;
            Name = dish.Name;
            CategoryId = dish.CategoryId;
            Description = dish.Description;
        }

    }
}