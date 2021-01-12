using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Web_NET.Areas.Models
{
    public class LoginModel
    {

        [Required]
        public string id { set; get; }
        public string MatKhau { set; get; }
        public bool? Rememberme { get; set; }
    }
}