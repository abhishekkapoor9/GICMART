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
        //[Required]
<<<<<<< HEAD
 
=======
>>>>>>> 9a74c8cf3862688ff8ebc0fd32a41909f9eca957
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
>>>>>>> 9a74c8cf3862688ff8ebc0fd32a41909f9eca957
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