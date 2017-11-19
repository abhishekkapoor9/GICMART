using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gicmart.Models
{
    public class users
    {
        [Display(Name = "User Id")]
<<<<<<< HEAD
        //[Required]
 
=======
>>>>>>> 10d877089640abff37ff7fb8814d4d50d4f5bed2
        [Required]
        public string userid { get; set; }//userid
        //[Display(Name = " sponsor id")]
        //[Required]
        public string sponsorid { get; set; }//sponsorid
        [Display(Name = "Sponsor Name")]
        [Required]
        public string sponsorname { get; set; }//sponsorname
<<<<<<< HEAD
 
        [Display(Name = "Pin No")]
=======

        [Display(Name = "PinNo")]
>>>>>>> 10d877089640abff37ff7fb8814d4d50d4f5bed2
        [Required]
        public string pin { get; set; }//pin
        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }//name
        public string mobileno { get; set; }//mobileno
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
        public bool termandcondition
        {
            get; set;

        }
    }
}