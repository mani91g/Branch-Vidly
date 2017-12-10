using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Helper
{
    public class AgeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {            
            var customer = (Customers)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.DefaultMembership || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.DateOfBirth == null)
                return new ValidationResult("Date of birth is required");

            TimeSpan t = (TimeSpan)(DateTime.Now - customer.DateOfBirth );

            var age = t.Days / 365;

            return (age < 18)? new ValidationResult("Customer should be above 18 years to have a membership")
                : ValidationResult.Success; ;

           

        }
    }
}