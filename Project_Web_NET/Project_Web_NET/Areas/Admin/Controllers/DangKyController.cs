using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelsMVC.Framework;
namespace Project_Web_NET.Areas.Admin.Controllers
{
    public class DangKyController : Controller
    {
        readonly QL_NhaTroDbContext db = new QL_NhaTroDbContext();
        [HttpPost]
        public JsonResult TrungTaiKhoan_ChuTro(ModelsMVC.Framework.ChuTro chutro)
        {
            var checkID = db.ChuTroes.Where(m => m.ChuTro_ID == chutro.ChuTro_ID).SingleOrDefault();
            return Json(checkID == null);
        }
        [HttpPost]
        public JsonResult TrungEmail_ChuTro(ModelsMVC.Framework.ChuTro chutro)
        {
            var checkEmail = db.ChuTroes.Where(m => m.Email == chutro.Email).SingleOrDefault();
            return Json(checkEmail == null);
        }
        [HttpPost]
        public JsonResult TrungTaiKhoan_NguoiDung(ModelsMVC.Framework.NguoiDung nguoidung)
        {
            var checkID = db.NguoiDungs.Where(m => m.NguoiDung_ID == nguoidung.NguoiDung_ID).SingleOrDefault();
            return Json(checkID == null);
        }
        [HttpPost]
        public JsonResult TrungEmail_NguoiDung(ModelsMVC.Framework.NguoiDung nguoidung)
        {
            var checkEmail = db.NguoiDungs.Where(m => m.Email == nguoidung.Email).SingleOrDefault();
            return Json(checkEmail == null);
        }
    }
}