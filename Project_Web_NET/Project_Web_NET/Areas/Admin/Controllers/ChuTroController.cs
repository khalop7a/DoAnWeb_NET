using ModelsMVC.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
namespace Project_Web_NET.Areas.Admin.Controllers
{
    public class ChuTroController : Controller
    {
        QL_NhaTroDbContext db = new QL_NhaTroDbContext();
        private static string getPassValue = "";


        [HttpGet]
        public PartialViewResult ds_chutro_ajax(string id = null)
        {
            var listchutro = db.ChuTroes.Where(x => x.ChuTro_ID == id).Select(x => x);
            return PartialView("ds_chutro_ajax", listchutro);

        }

        [HttpGet]
        public ActionResult danhsach_chutro()
        {
            List<SelectListItem> query = db.ChuTroes.Select(s => new SelectListItem { Text = s.TenNhaTro, Value = s.ChuTro_ID }).ToList();
            ViewBag.TenNhaTro = query;
            var listchutro = db.ChuTroes.Select(x => x);
            return View(listchutro);
        }

        [HttpGet]
        public void GetPassValue(string idPass)
        {
            getPassValue = idPass;
        }

        [HttpGet]
        public ActionResult them_chutro()
        {
            return View();
        }

        public bool KiemTraKhoaChinh(string id)
        {
            ModelsMVC.Framework.ChuTro chutro = db.ChuTroes.SingleOrDefault(s => s.ChuTro_ID == id);
            if (chutro == null)
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
        public ActionResult them_chutro(ModelsMVC.Framework.ChuTro chutro)
        {
            try
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
                    return View(chutro);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", " Error save data");
            }
            List<SelectListItem> query = db.ChuTroes.Select(s => new SelectListItem { Text = s.TenNhaTro, Value = s.ChuTro_ID }).ToList();
            ViewBag.TenNhaTro = query;
            var listchutro = from s in db.ChuTroes select s;
            return View("danhsach_chutro", listchutro);
        }

        [HttpGet]
        public ActionResult sua_chutro(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelsMVC.Framework.ChuTro chutro = db.ChuTroes.SingleOrDefault(s => s.ChuTro_ID == id);
            return View(chutro);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult sua_chutro(string id, string submit)
        {
            try
            {
                var timchutro = db.ChuTroes.Find(id);
                timchutro.NhapLaiMatKhau = timchutro.MatKhau;
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(timchutro, "", new string[] { "Email", "SDT", "TenNhaTro", "DiaChi" }))
                    {
                        try
                        {
                            db.Entry(timchutro).State = EntityState.Modified;
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
            List<SelectListItem> query = db.ChuTroes.Select(s => new SelectListItem { Text = s.TenNhaTro, Value = s.ChuTro_ID }).ToList();
            ViewBag.TenNhaTro = query;
            return RedirectToAction("danhsach_chutro");
        }

        [HttpGet]
        public ActionResult xoa_chutro(string id)
        {
            ModelsMVC.Framework.ChuTro chutro = db.ChuTroes.SingleOrDefault(s => s.ChuTro_ID == id);
            if (chutro == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(chutro);
        }

        [HttpPost]
        public ActionResult xoa_chutro(string id, string submit)
        {
            switch (submit)
            {
                case "Xóa":
                    try
                    {
                        ModelsMVC.Framework.ChuTro timchutro = db.ChuTroes.SingleOrDefault(s => s.ChuTro_ID == id);

                        if (timchutro == null)
                        {
                            Response.StatusCode = 404;
                            return null;
                        }
                        db.ChuTroes.Remove(timchutro);
                        db.SaveChanges();
                    }
                    catch (RetryLimitExceededException)
                    {
                        ModelState.AddModelError("", " Error delete data");
                    }
                    List<SelectListItem> query = db.ChuTroes.Select(s => new SelectListItem { Text = s.TenNhaTro, Value = s.ChuTro_ID }).ToList();
                    ViewBag.TenNhaTro = query;
                    return RedirectToAction("danhsach_chutro", "ChuTro");

                case "Trở về":
                    return RedirectToAction("danhsach_chutro");

                default:
                    throw new Exception();
            }
        }
    }
}