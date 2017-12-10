using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Helper;

namespace WebApplication1.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

        public bool IsSubscibed { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        //[AgeValidator]
        public DateTime? DateOfBirth { get; set; }
    }
}