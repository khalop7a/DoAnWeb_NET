using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Web_NET.Areas.ChuTro.Controllers
{
    public class HomeController : Controller
    {
        // GET: ChuTro/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}