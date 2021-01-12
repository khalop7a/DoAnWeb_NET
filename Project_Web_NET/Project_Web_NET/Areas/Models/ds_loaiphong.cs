using ModelsMVC.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Web_NET.Areas.Models
{
  
    public class ds_loaiphong
    {
        QL_NhaTroDbContext db = null;
        public ds_loaiphong()
        {
            db = new QL_NhaTroDbContext();
        }

        public List<LoaiPhong> ListLoaiPhong()
        {
            return db.LoaiPhongs.ToList();
        }
    }
}