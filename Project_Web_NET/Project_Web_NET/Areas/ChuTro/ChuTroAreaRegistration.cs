using System.Web.Mvc;

namespace Project_Web_NET.Areas.ChuTro
{
    public class ChuTroAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ChuTro";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ChuTro_default",
                "ChuTro/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Project_Web_NET.Areas.ChuTro.Controllers" }
            );
        }
    }
}