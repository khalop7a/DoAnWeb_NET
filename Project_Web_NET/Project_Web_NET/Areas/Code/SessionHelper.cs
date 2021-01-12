using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Web_NET.Areas.Code
{
    public class SessionHelper
    {
        public static void SetSessionCT(ChuTroSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }

        public static ChuTroSession GetSessionCT()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if (session == null)
                return null;
            else
            {
                return session as ChuTroSession;
            }
        }
        public static void SetSessionAdmin(AdminSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }

        public static AdminSession GetSessionAdmin()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if (session == null)
                return null;
            else
            {
                return session as AdminSession;
            }
        }


        public static void SetSessionNguoiDung(NguoiDungSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }

        public static NguoiDungSession GetSessionNguoiDung()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if (session == null)
                return null;
            else
            {
                return session as NguoiDungSession;
            }
        }
    }
}