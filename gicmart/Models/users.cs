using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gicmart.Models
{
    public class users
    {
        [Display(Name = "user id")]
        [Required]
        public string userid { get; set; }
        [Display(Name = " sponsor id")]
        [Required]
        public string sponsorid { get; set; }
        [Display(Name = "sponsor name")]
        [Required]
        public string sponsorname { get; set; }
        [Display(Name = "pin")]
        [Required]
        public string pin { get; set; }
        [Display(Name = "name")]
        [Required]
        public string name { get; set; }
        public int mobileno { get; set; }
        [Display(Name = "password")]
        [Required]
        public string password { get; set; } 
        public string pancardno { get; set; }
        public string nomineename { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        [Required]
        public bool termandcondition { get; set; }
 
    }
}