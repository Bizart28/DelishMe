using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DelishMe.Web.Models;

namespace DelishMe.Web.ViewModels
{
    public class DishFormViewModel
    
        {
        public IEnumerable<Category> Categories { get; set; }
        public Dish Dish { get; set; }
        public string Title
        {
            get
            {
                if (Dish != null && Dish.Id != 0)
                    return "Edit Dish";

                return "New Dish";
            }
        }
    
}
}