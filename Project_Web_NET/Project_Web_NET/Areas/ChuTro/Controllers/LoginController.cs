using Project_Web_NET.Areas.Code;
using Project_Web_NET.Areas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Web_NET.Areas.ChuTro.Controllers
{
    public class LoginController : Controller
    {
        // GET: ChuTro/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginChuTroModel model)
        {
            var result = new ModelsMVC.ChuTro().Login(model.ChuTro_ID, model.MatKhau);
            if (result && ModelState.IsValid)
            {
                //Nếu thành công chúng ta cần tạo session
                SessionHelper.SetSessionCT(new ChuTroSession(model.ChuTro_ID));
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu chủ trọ không đúng!");
            }
            return View(model);
        }
    }

}