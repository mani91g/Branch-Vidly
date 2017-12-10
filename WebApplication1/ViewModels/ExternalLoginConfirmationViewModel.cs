using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;


namespace WebApplication1.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Email")]
        public string AadharNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
    }
}