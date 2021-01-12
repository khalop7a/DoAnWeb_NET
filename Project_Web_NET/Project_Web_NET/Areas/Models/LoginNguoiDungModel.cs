using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Web_NET.Areas.Models
{
    public class LoginNguoiDungModel
    {
        [Required]
        public string NguoiDung_ID { set; get; }
        public string MatKhau { set; get; }
        public Boolean Rememberme { set; get; }
    }
}