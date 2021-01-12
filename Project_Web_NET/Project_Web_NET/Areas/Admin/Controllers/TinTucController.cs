using ModelsMVC.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Web_NET.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        QL_NhaTroDbContext db = new QL_NhaTroDbContext();

      

        [HttpGet]
        public PartialViewResult ds_tintuc_ajax(string tieude)
        {
            var listtintuc = db.TinTucs.Where(x => x.TieuDe == tieude).Select(x => x);
            return PartialView("ds_tintuc_ajax", listtintuc);

        }

        [HttpGet]
        public ActionResult danhsach_tintuc(int page = 1, int pagesize = 2)
        {
            List<SelectListItem> query = db.TinTucs.Select(s => new SelectListItem { Text = s.TieuDe, Value = s.TieuDe }).ToList();
            ViewBag.TinTuc = query;
            var listPage = new ModelsMVC.TinTucModel();
            var listtintuc = listPage.ListAllPage(page, pagesize);
            return View(listtintuc);
        }



        [HttpGet]
        public ActionResult xoa_tintuc(int id)
        {
            ModelsMVC.Framework.TinTuc tintuc = db.TinTucs.SingleOrDefault(s => s.TinTuc_ID == id);
            if (tintuc == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(tintuc);
        }

        [HttpPost]
        public ActionResult xoa_tintuc(int id, string submit)
        {
            switch (submit)
            {
                case "Xóa":
                    try
                    {
                        ModelsMVC.Framework.TinTuc timtintuc = db.TinTucs.SingleOrDefault(s => s.TinTuc_ID == id);

                        if (timtintuc == null)
                        {
                            Response.StatusCode = 404;
                            return null;
                        }
                        db.TinTucs.Remove(timtintuc);
                        db.SaveChanges();
                    }
                    catch (RetryLimitExceededException)
                    {
                        ModelState.AddModelError("", " Error delete data");
                    }
                    List<SelectListItem> query = db.TinTucs.Select(s => new SelectListItem { Text = s.TieuDe, Value = s.TieuDe }).ToList();
                    ViewBag.TinTuc = query;
                    return RedirectToAction("danhsach_tintuc", "TinTuc");

                case "Trở về":
                    return RedirectToAction("danhsach_tintuc");

                default:
                    throw new Exception();
            }
        }
    }
}