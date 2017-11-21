using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gicmart.Models;
using System.ComponentModel.DataAnnotations;

namespace gicmart.Areas.User.Models
{
    public class userprofile
    {
        public string sponsorid { get; set; }
        public string pin { get; set; }
        public string userid { get; set; }
        public string name { get; set; }
        public string mobileno { get; set; }
        public string password { get; set; }
        public string pancardno { get; set; }
        public string nominee { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string holdername { get; set; }
        public int accountno { get; set; }
        public string bankname { get; set; }
        public string ifsccode { get; set; }

    }
}