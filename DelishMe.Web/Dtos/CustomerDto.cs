using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DelishMe.Web.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        [ForeignKey("MembershipType")]
        public byte MembershipTypeId { get; set; }
       //[_18YearsValidation]
        public DateTime? Birthdate { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
    }
}