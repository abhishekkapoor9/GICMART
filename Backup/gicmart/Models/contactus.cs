using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace gicmart.Models
{
    public class contactus
    {
        public string name { get; set; }
        [Display(Name = "Email")]
        [Required]
       
        public string email { get; set; }
        public string phoneno { get; set; }
        [Display(Name = "nessage")]
        [Required]
        public string message { get; set; }
    }
}