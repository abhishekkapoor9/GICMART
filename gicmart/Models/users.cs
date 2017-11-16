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
        public string userid { get; set; }//userid
        [Display(Name = " sponsor id")]
        [Required]
        public string sponsorid { get; set; }//sponsorid
        [Display(Name = "sponsor name")]
        [Required]
        public string sponsorname { get; set; }//sponsorname
        [Display(Name = "pin")]
        [Required]
        public string pin { get; set; }//pin
        [Display(Name = "name")]
        [Required]
        public string name { get; set; }//name
        public int mobileno { get; set; }//mobileno
        [Display(Name = "Password")]
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