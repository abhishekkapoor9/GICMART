using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gicmart.Models
{
    public class users
    {
<<<<<<< HEAD
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
=======
        [Display(Name = "User Id")]
        [Required]
        public string userid { get; set; }
        [Display(Name = " Sponsor Id")]
        [Required]
        public string sponsorid { get; set; }
        [Display(Name = "Sponsor Name")]
        [Required]
        public string sponsorname { get; set; }
        [Display(Name = "Pin No")]
        [Required]
        public string pin { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }
        public int mobileno { get; set; }
        [Display(Name = "Password")]
>>>>>>> dea32c7c70e9e2aa4dc845e6bd30901841ff8d73
        [Required]
        public string password { get; set; }
        [Display(Name = "Pan Card No ")]
        public string pancardno { get; set; }
        [Display(Name = "Nominee Name")]
        public string nomineename { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }

            [Display(Name = "State")]
            public string state { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Required]
        [Display(Name = "Term And Condition")]
        public bool termandcondition { get; set; }
 
    }
}