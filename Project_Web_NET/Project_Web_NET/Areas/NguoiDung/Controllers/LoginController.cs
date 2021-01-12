using Project_Web_NET.Areas.Code;
using Project_Web_NET.Areas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Web_NET.Areas.NguoiDung.Controllers
{
    public class LoginController : Controller
    {
            [HttpGet]
            public ActionResult Index()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Index(LoginNguoiDungModel model)
            {
                var result = new ModelsMVC.NguoiDung().Login(model.NguoiDung_ID, model.MatKhau);
                if (result && ModelState.IsValid)
                {
                    //Nếu thành công chúng ta cần tạo session
                    SessionHelper.SetSessionNguoiDung(new NguoiDungSession(model.NguoiDung_ID));
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Index","Home", new { area = "" });
            }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu người dùng không đúng!");
                }
                return View(model);
            }
    }
}