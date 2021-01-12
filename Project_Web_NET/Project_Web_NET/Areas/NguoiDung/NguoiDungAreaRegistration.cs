﻿using System.Web.Mvc;

namespace Project_Web_NET.Areas.NguoiDung
{
    public class NguoiDungAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NguoiDung";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NguoiDung_default",
                "NguoiDung/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}