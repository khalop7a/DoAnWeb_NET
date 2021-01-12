using ModelsMVC.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Project_Web_NET.Controllers
{
    public class DangKyController : Controller
    {
        readonly QL_NhaTroDbContext db = new QL_NhaTroDbContext();
        public ActionResult Welcome()
        {
            return View();
        }

        public static string GetMD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
            {
                sbHash.Append(string.Format("{0:x2}", b));
            }
            return sbHash.ToString();
        }

        public ActionResult GetForm(string table)
        {
            if (table == "Chủ trọ")
            {
                return View("DangKyChuTro");
            }
            else
            {
                return View("DangKyNguoiDung");
            }
        }

        public ActionResult DangKyChuTro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKyChuTro(ChuTro chutro)
        {
            if (ModelState.IsValid)
            {
                chutro.MatKhau = GetMD5(chutro.MatKhau);
                chutro.NhapLaiMatKhau = GetMD5(chutro.NhapLaiMatKhau);
                db.ChuTroes.Add(chutro);
                db.SaveChanges();
            }
            else
            {
                return Content("Error");
            }
            return View("DangKyNguoiDung");
        }

        public ActionResult DangKyNguoiDung()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKyNguoiDung(NguoiDung nguoidung)
        {
            if (ModelState.IsValid)
            {
                nguoidung.MatKhau = GetMD5(nguoidung.MatKhau);
                nguoidung.NhapLaiMatKhau = GetMD5(nguoidung.NhapLaiMatKhau);
                db.NguoiDungs.Add(nguoidung);
                db.SaveChanges();
            }
            else
            {
                return Content("Error");
            }
            return View("DangKyChuTro");
        }
        [HttpPost]
        public JsonResult TrungTaiKhoan_ChuTro(ChuTro chutro)
        {
            var checkID = db.ChuTroes.Where(m => m.ChuTro_ID == chutro.ChuTro_ID).SingleOrDefault();
            return Json(checkID == null);
        }
        [HttpPost]
        public JsonResult TrungEmail_ChuTro(ChuTro chutro)
        {
            var checkEmail = db.ChuTroes.Where(m => m.Email == chutro.Email).SingleOrDefault();
            return Json(checkEmail == null);
        }
        [HttpPost]
        public JsonResult TrungTaiKhoan_NguoiDung(NguoiDung nguoidung)
        {
            var checkID = db.NguoiDungs.Where(m => m.NguoiDung_ID == nguoidung.NguoiDung_ID).SingleOrDefault();
            return Json(checkID == null);
        }
        [HttpPost]
        public JsonResult TrungEmail_NguoiDung(NguoiDung nguoidung)
        {
            var checkEmail = db.NguoiDungs.Where(m => m.Email == nguoidung.Email).SingleOrDefault();
            return Json(checkEmail == null);
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}