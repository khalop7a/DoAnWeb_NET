using ModelsMVC.Framework;
using Project_Web_NET.Areas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project_Web_NET.Areas.Admin.Controllers
{
    public class PhongController : Controller
    {
        QL_NhaTroDbContext db = new QL_NhaTroDbContext();

        public void setViewBag(int selectedLoaiPhongID = 0, int selectedChuTroID = 0)
        {
            var ds_loaiphong  = new ds_loaiphong();
            var ds_chutro = new ds_chutro(); 
            ViewBag.LoaiPhong_ID = new SelectList(ds_loaiphong.ListLoaiPhong(), "LoaiPhong_ID", "TenLoai", selectedLoaiPhongID);
            ViewBag.ChuTro_ID = new SelectList(ds_chutro.ListChuTro(), "ChuTro_ID", "TenNhaTro", selectedChuTroID);
        }

        [HttpGet]
        public PartialViewResult ds_phong_ajax(int id)
        {
            var listphong = db.Phongs.Where(x => x.LoaiPhong_ID == id).Select(x => x);
            return PartialView("ds_phong_ajax", listphong);
        }

        [HttpGet]
        public ActionResult danhsach_phong()
        {
            List<SelectListItem> query = db.LoaiPhongs.Select(s => new SelectListItem { Text = s.TenLoai, Value = s.LoaiPhong_ID.ToString() }).ToList();
            ViewBag.Phong = query;
            var listphong = db.Phongs.Select(x => x);
            return View(listphong);
        }
 
        [HttpGet]
        public ActionResult them_phong()
        {
            setViewBag();
            return View();
        }

        [HttpPost, ActionName("them_phong")]
        [ValidateInput(false)]
        public ActionResult them_phong(ModelsMVC.Framework.Phong phong, string submit, HttpPostedFileBase fileUpload)
        {
            switch (submit)
            {
                case "Lưu":
                    try
                    {
                        setViewBag();
                        if (ModelState.IsValid)
                        {
                            //Upload file
                            var fileName = Path.GetFileName(fileUpload.FileName);
                            //Console.WriteLine(fileName);
                            //Lưu đường dẫn file ảnh 
                            var path = Path.Combine(Server.MapPath("~/Content/Image"), fileName);
                            //Kiểm tra file đã tồn tại
                            if (System.IO.File.Exists(path))
                            {
                                ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                            }
                            else
                            {
                                fileUpload.SaveAs(path);
                            }
                            //Them Sach Moi
                            phong.HinhAnh = fileUpload.FileName;
                            db.Phongs.Add(phong);
                            db.SaveChanges();
                        }
                        else
                        {
                            return View(phong);
                        }

                    }
                    catch (RetryLimitExceededException)
                    {
                        ModelState.AddModelError("", " Error save data");
                    }
                    List<SelectListItem> query = db.Phongs.Select(s => new SelectListItem { Text = s.LoaiPhong_ID.ToString(), Value = s.Phong_ID.ToString() }).ToList();
                    ViewBag.Phong = query;
                    var listphong = from s in db.Phongs select s;
                    return View("danhsach_phong", listphong);

                case "Trở về":
                    return RedirectToAction("danhsach_phong", "Phong");

                default:
                    throw new Exception();
            }
        }

        [HttpGet]
        public ActionResult sua_phong(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelsMVC.Framework.Phong phong = db.Phongs.SingleOrDefault(s => s.Phong_ID == id);
            setViewBag();
            return View(phong);
        }

        [HttpPost, ActionName("sua_phong")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult sua_phong(int id, string submit, HttpPostedFileBase fileUpload)
        {
            switch (submit)
            {
                case "Lưu":
                    try
                    {
                        setViewBag();
                        var timphong = db.Phongs.Find(id);
                        Console.WriteLine(timphong);

                        if (ModelState.IsValid)
                        {
                            if (TryUpdateModel(timphong, "", new string[] { "LoaiPhong_ID", "ChuTro_ID", "DienTich", "Gia", "DiaChi", "MoTa", "SoLuong", "HinhAnh" }))

                            {
                                try
                                {
                                    var fileName = Path.GetFileName(fileUpload.FileName);
                                    //Console.WriteLine(fileName);
                                    //Lưu đường dẫn file ảnh 
                                    var path = Path.Combine(Server.MapPath("~/Content/Image"), fileName);
                                    //Kiểm tra file đã tồn tại
                                    if (System.IO.File.Exists(path))
                                    {
                                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                                    }
                                    else
                                    {
                                        fileUpload.SaveAs(path);
                                    }
                                    timphong.HinhAnh = fileUpload.FileName;

                                    db.Entry(timphong).State = EntityState.Modified;
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
                    List<SelectListItem> query = db.Phongs.Select(s => new SelectListItem { Text = s.LoaiPhong_ID.ToString(), Value = s.Phong_ID.ToString() }).ToList();
                    ViewBag.Phong = query;
                    return RedirectToAction("danhsach_phong");
                case "Trở về":
                    return RedirectToAction("danhsach_phong");

                default:
                    throw new Exception();
            }
        }

        [HttpGet]
        public ActionResult xoa_phong(int id)
        {
            ModelsMVC.Framework.Phong phong = db.Phongs.SingleOrDefault(s => s.Phong_ID == id);
            if (phong == null)
            {
                Response.StatusCode = 404;
                return null;
            }
         
            return View(phong);
        }

        [HttpPost]
        public ActionResult xoa_phong(int id, string submit)
        {
            switch (submit)
            {
                case "Xóa":
                    try
                    {
                        ModelsMVC.Framework.Phong timphong = db.Phongs.SingleOrDefault(s => s.Phong_ID == id);

                        if (timphong == null)
                        {
                            Response.StatusCode = 404;
                            return null;
                        }
                        db.Phongs.Remove(timphong);
                        db.SaveChanges();
                    }
                    catch (RetryLimitExceededException)
                    {
                        ModelState.AddModelError("", " Error delete data");
                    }
                    List<SelectListItem> query = db.Phongs.Select(s => new SelectListItem { Text = s.LoaiPhong_ID.ToString(), Value = s.Phong_ID.ToString() }).ToList();
                    ViewBag.Phong = query;
                    return RedirectToAction("danhsach_phong", "Phong");

                case "Trở về":
                    return RedirectToAction("danhsach_phong");

                default:
                    throw new Exception();
            }
        }
    }
}