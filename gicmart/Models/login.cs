using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gicmart.Models
{
    public class login
    {
        [Display(Name = "User Name")]
        [Required]
        public string userName { get; set; }//userid

        [Display(Name = "Password")]
        [Required]
        public string userPassword { get; set; }//Passwr

        public string role { get; set; }//userid
    }
}