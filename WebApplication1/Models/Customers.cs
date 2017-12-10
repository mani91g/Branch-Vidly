using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Helper;

namespace WebApplication1.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }

        public bool IsSubscibed { get; set; }
       
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        
        [AgeValidator]
        [Display(Name ="Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
    }
}