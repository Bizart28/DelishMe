using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelishMe.Web.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name required")]
        [StringLength(100,ErrorMessage = "Minimum 3 and Maximum 100 characters are allowed", MinimumLength = 3)]
        public string CategoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
