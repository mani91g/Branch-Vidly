using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Genre
    {        
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name="Genre")]
        public string Name { get; set; }
    }
}