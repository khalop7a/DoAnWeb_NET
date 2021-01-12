using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Web_NET.Areas.Code
{
    [Serializable] //Tự động hoá nhị phân
    public class ChuTroSession
    {
        private string ChuTro_ID { set; get; }
        public ChuTroSession(string UserName)
        {
            this.ChuTro_ID = UserName;
        }

    }
}