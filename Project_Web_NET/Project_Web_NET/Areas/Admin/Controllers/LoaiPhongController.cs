using ModelsMVC.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project_Web_NET.Areas.Admin.Controllers
{
    public class LoaiPhongController : Controller
    {
        QL_NhaTroDbContext db = new QL_NhaTroDbContext();

        [HttpGet]
        public PartialViewResult ds_loaiphong_ajax(int id)
        {
            var listloaiphong = db.LoaiPhongs.Where(x => x.LoaiPhong_ID == id).Select(x => x);
            return PartialView("ds_loaiphong_ajax", listloaiphong);

        }

        [HttpGet]
        public ActionResult danhsach_loaiphong()
        {
            List<SelectListItem> query = db.LoaiPhongs.Select(s => new SelectListItem { Text = s.TenLoai, Value = s.LoaiPhong_ID.ToString() }).ToList();
            ViewBag.TenLoaiPhong = query;
            var listloaiphong = db.LoaiPhongs.Select(x => x);
            return View(listloaiphong);
        }
      
        [HttpGet]
        public ActionResult them_loaiphong()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult them_loaiphong(ModelsMVC.Framework.LoaiPhong loaiphong, string submit)
        {
            switch (submit)
            {
                case "Lưu":
                    try
                    {
                        if (ModelState.IsValid)
                        {
                                db.LoaiPhongs.Add(loaiphong);
                                db.SaveChanges();
                            
                        }
                        else
                        {
                            return View(loaiphong);
                        }

                    }
                    catch (RetryLimitExceededException)
                    {
                        ModelState.AddModelError("", " Error save data");
                    }
                    List<SelectListItem> query = db.LoaiPhongs.Select(s => new SelectListItem { Text = s.TenLoai, Value = s.LoaiPhong_ID.ToString() }).ToList();
                    ViewBag.TenLoaiPhong = query;
                    var listloaiphong = from s in db.LoaiPhongs select s;
                    return View("danhsach_loaiphong", listloaiphong);

                case "Trở về":
                    return RedirectToAction("danhsach_loaiphong", "LoaiPhong");

                default:
                    throw new Exception();

            }
        }

        [HttpGet]
        public ActionResult sua_loaiphong(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelsMVC.Framework.LoaiPhong loaiphong = db.LoaiPhongs.SingleOrDefault(s => s.LoaiPhong_ID == id);
            return View(loaiphong);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult sua_loaiphong(int id, string submit)
        {
            switch (submit)
            {
                case "Lưu":
                    try
                    {
                        var timloaiphong = db.LoaiPhongs.Find(id);
                        if (TryUpdateModel(timloaiphong, "", new string[] { "TenLoai"}))
                        {
                            try
                            {
                                db.Entry(timloaiphong).State = EntityState.Modified;
                                db.SaveChanges();

                            }
                            catch (RetryLimitExceededException)
                            {
                                ModelState.AddModelError("", "Error update data");
                            }
                        }
                    }
                    catch (RetryLimitExceededException)
                    {
                        ModelState.AddModelError("", " Error save data");
                    }
                    List<SelectListItem> query = db.LoaiPhongs.Select(s => new SelectListItem { Text = s.TenLoai, Value = s.LoaiPhong_ID.ToString() }).ToList();
                    ViewBag.TenLoaiPhong = query;
                    return RedirectToAction("danhsach_loaiphong");
                case "Trở về":
                    return RedirectToAction("danhsach_loaiphong");

                default:
                    throw new Exception();
            }
        }

        [HttpGet]
        public ActionResult xoa_loaiphong(int id)
        {
            ModelsMVC.Framework.LoaiPhong loaiphong = db.LoaiPhongs.SingleOrDefault(s => s.LoaiPhong_ID == id);
            if (loaiphong == null)
            {
                Response.StatusCode = 404;
                return null;
            }
          
            return View(loaiphong);
        }

        [HttpPost]
        public ActionResult xoa_loaiphong(int id, string submit)
        {
            switch (submit)
            {
                case "Xóa":
                    try
                    {
                        ModelsMVC.Framework.LoaiPhong timloaiphong = db.LoaiPhongs.SingleOrDefault(s => s.LoaiPhong_ID == id);

                        if (timloaiphong == null)
                        {
                            Response.StatusCode = 404;
                            return null;
                        }
                        db.LoaiPhongs.Remove(timloaiphong);
                        db.SaveChanges();
                    }
                    catch (RetryLimitExceededException)
                    {
                        ModelState.AddModelError("", " Error delete data");
                    }
                    List<SelectListItem> query = db.LoaiPhongs.Select(s => new SelectListItem { Text = s.TenLoai, Value = s.LoaiPhong_ID.ToString() }).ToList();
                    ViewBag.TenLoaiPhong = query;
                    return RedirectToAction("danhsach_loaiphong", "LoaiPhong");

                case "Trở về":
                    return RedirectToAction("danhsach_loaiphong");

                default:
                    throw new Exception();
            }
        }
    }

}