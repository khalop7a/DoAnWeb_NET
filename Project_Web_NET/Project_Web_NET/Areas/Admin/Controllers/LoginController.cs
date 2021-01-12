using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Web_NET.Areas.Code;
using Project_Web_NET.Areas.Models;

namespace Project_Web_NET.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new ModelsMVC.Admin().Login(model.id, model.MatKhau);
            if (result && ModelState.IsValid)
            {
                //Nếu thành công chúng ta cần tạo session
                SessionHelper.SetSessionAdmin(new AdminSession(model.id));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu ADMIN không đúng!");
            }
            return View(model);
        }
    }
}