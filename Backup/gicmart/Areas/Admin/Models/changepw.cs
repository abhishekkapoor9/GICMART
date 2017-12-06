using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gicmart.Areas.Admin.Models
{
    public class changepw
    {
        public string oldpw { get; set; }
        public string newpw { get; set; }
        public string confirmpw { get; set; }
    }
}