using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Web_NET.Areas.Code
{
    [Serializable] //Tự động hoá nhị phân
    public class AdminSession
    {

        private string id { set; get; }
        public AdminSession(string UserName)
        {
            this.id = UserName;
        }
    }
}