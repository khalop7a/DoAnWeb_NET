using ModelsMVC.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
namespace Project_Web_NET.Areas.Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        QL_NhaTroDbContext db = new QL_NhaTroDbContext();
        private static int getValue = 0;
        [HttpGet]
        public PartialViewResult ds_nguoidung_ajax(string id = null)
        {
            var listnguoidung = db.NguoiDungs.Where(x => x.NguoiDung_ID == id).Select(x => x);
            return PartialView("ds_nguoidung_ajax", listnguoidung);

        }

        [HttpGet]
        public ActionResult danhsach_nguoidung()
        {

            List<SelectListItem> query = db.NguoiDungs.Select(s => new SelectListItem { Text = s.HoTen, Value = s.NguoiDung_ID }).ToList();
            ViewBag.TenNguoiDung = query;
            var listnguoidung = db.NguoiDungs.Select(x => x);
            return View(listnguoidung);
        }

        [HttpGet]
        public ActionResult them_nguoidung()
        {
          
            return View();
        }
        [HttpGet]
        public void GetValue(int id)
        {
            getValue = id;
        }

       
        public bool KiemTraKhoaChinh(string id)
        {
            ModelsMVC.Framework.NguoiDung nguoidung = db.NguoiDungs.SingleOrDefault(s => s.NguoiDung_ID == id);
            if (nguoidung == null)
            {
                return true;
            }
            return false;
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
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult them_nguoidung(ModelsMVC.Framework.NguoiDung nguoidung)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Mã hóa Passwork ---Author: Duy
                    nguoidung.MatKhau = GetMD5(nguoidung.MatKhau);
                    nguoidung.NhapLaiMatKhau = GetMD5(nguoidung.NhapLaiMatKhau);
                    db.NguoiDungs.Add(nguoidung);
                    db.SaveChanges();
                }
                else
                {
                    return View(nguoidung);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", " Error save data");
            }
            List<SelectListItem> query = db.NguoiDungs.Select(s => new SelectListItem { Text = s.HoTen, Value = s.NguoiDung_ID }).ToList();
            ViewBag.TenNguoiDung = query;
            var listnguoidung = from s in db.NguoiDungs select s;
            return View("danhsach_nguoidung", listnguoidung);
        }

        [HttpGet]
        public ActionResult sua_nguoidung(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelsMVC.Framework.NguoiDung nguoidung = db.NguoiDungs.SingleOrDefault(s => s.NguoiDung_ID == id);
            return View(nguoidung);
        }

        [HttpPost, ActionName("sua_nguoidung")]
        //[ValidateInput(false)]
        //[ValidateAntiForgeryToken]
        public ActionResult sua_nguoidung_POST(string id)
        {
            try
            {
                var timnguoidung = db.NguoiDungs.Find(id);
                //Tránh null
                timnguoidung.NhapLaiMatKhau = timnguoidung.MatKhau;
                //timnguoidung.Rememberme = false;
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(timnguoidung, "", new string[] { "HoTen", "GioiTinh", "SDT", "DiaChi" }))
                    {
                        try
                        {
                            db.Entry(timnguoidung).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Error update data");
                        }
                    }
                }
             }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", " Error save data");
            }
            List<SelectListItem> query = db.NguoiDungs.Select(s => new SelectListItem { Text = s.HoTen, Value = s.NguoiDung_ID }).ToList();
            ViewBag.TenNguoiDung = query;
            return RedirectToAction("danhsach_nguoidung");
        }

        [HttpGet]
        public ActionResult xoa_nguoidung(string id)
        {
            ModelsMVC.Framework.NguoiDung nguoidung = db.NguoiDungs.SingleOrDefault(s => s.NguoiDung_ID == id);
            if (nguoidung == null)
            {
                Response.StatusCode = 404;
                return null;
            }
           
            return View(nguoidung);
        }

        [HttpPost]
        public ActionResult xoa_nguoidung(string id, string submit)
        {
            switch (submit)
            {
                case "Xóa":
                    try
                    {
                        ModelsMVC.Framework.NguoiDung timnguoidung = db.NguoiDungs.SingleOrDefault(s => s.NguoiDung_ID == id);

                        if (timnguoidung == null)
                        {
                            Response.StatusCode = 404;
                            return null;
                        }
                        db.NguoiDungs.Remove(timnguoidung);
                        db.SaveChanges();
                    }
                    catch (RetryLimitExceededException)
                    {
                        ModelState.AddModelError("", " Error delete data");
                    }
                    List<SelectListItem> query = db.NguoiDungs.Select(s => new SelectListItem { Text = s.HoTen, Value = s.NguoiDung_ID }).ToList();
                    ViewBag.TenNguoiDung = query;
                    return RedirectToAction("danhsach_nguoidung", "NguoiDung");

                case "Trở về":
                    return RedirectToAction("danhsach_nguoidung");

                default:
                    throw new Exception();
            }
        }
    }
}