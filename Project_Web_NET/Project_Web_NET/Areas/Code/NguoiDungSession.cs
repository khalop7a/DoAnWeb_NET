using System;


namespace Project_Web_NET.Areas.Code
{
    [Serializable] //Tự động hoá nhị phân
    public class NguoiDungSession
    {

        private string NguoiDung_ID { set; get; }
        public NguoiDungSession(string UserName)
        {
            this.NguoiDung_ID = UserName;
        }
    }
}