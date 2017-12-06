using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gicmart.Areas.User.Models
{
    public class changePassword
    {
        public string oldPass { get; set; }

        public string changePass { get; set; }

        [Compare("changePass", ErrorMessage = "New Password and Old Password doesn't match")]

        public string confirmPass { get; set; }
    }
}