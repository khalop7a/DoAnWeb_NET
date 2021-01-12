using ModelsMVC.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Web_NET.Areas.Admin.Controllers
{
    public class DanhGiaController : Controller
    {
        QL_NhaTroDbContext db = new QL_NhaTroDbContext();


        [HttpGet]
        public PartialViewResult ds_danhgia_ajax(int id)
        {
            var listdanhgia = db.DanhGias.Where(x => x.Phong_ID == id).Select(x => x);
            return PartialView("ds_danhgia_ajax", listdanhgia);

        }

        [HttpGet]
        public ActionResult danhsach_danhgia(int page = 1, int pagesize = 2)
        {
            List<SelectListItem> query = db.DanhGias.Select(s => new SelectListItem { Text = s.Phong_ID.ToString(), Value = s.Phong_ID.ToString() }).ToList();
            ViewBag.DanhGia = query;
            //var listdanhgia = db.DanhGias.Select(x => x);
            var listPage = new ModelsMVC.DanhGiaModel();
            var listdanhgia = listPage.ListAllPage(page, pagesize);
            return View(listdanhgia);
        }
   
       
        [HttpGet]
        public ActionResult xoa_danhgia(int id)
        {
            ModelsMVC.Framework.DanhGia danhgia = db.DanhGias.SingleOrDefault(s => s.DanhGia_ID == id);
            if (danhgia == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(danhgia);
        }

        [HttpPost]
        public ActionResult xoa_danhgia(int id, string submit)
        {
            switch (submit)
            {
                case "Xóa":
                    try
                    {
                        ModelsMVC.Framework.DanhGia timdanhgia = db.DanhGias.SingleOrDefault(s => s.DanhGia_ID == id);

                        if (timdanhgia == null)
                        {
                            Response.StatusCode = 404;
                            return null;
                        }
                        db.DanhGias.Remove(timdanhgia);
                        db.SaveChanges();
                    }
                    catch (RetryLimitExceededException)
                    {
                        ModelState.AddModelError("", " Error delete data");
                    }
                    List<SelectListItem> query = db.DanhGias.Select(s => new SelectListItem { Text = s.Phong_ID.ToString(), Value = s.Phong_ID.ToString() }).ToList();
                    ViewBag.DanhGia = query;
                    return RedirectToAction("danhsach_danhgia", "DanhGia");

                case "Trở về":
                    return RedirectToAction("danhsach_danhgia");

                default:
                    throw new Exception();
            }
        }
    }
}