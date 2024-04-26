using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DelishMe.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }   
        public bool IsSubscribedToNewsLetter { get; set; }
        public  MembershipType MembershipType { get; set; }
        [ForeignKey("MembershipType")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        [_18YearsValidation]
        public DateTime? Birthdate { get; set; }

    }
}