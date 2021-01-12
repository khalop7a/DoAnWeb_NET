using ModelsMVC.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Web_NET.Areas.Models
{
    public class ds_chutro
    {
        QL_NhaTroDbContext db = null;
        public ds_chutro()
        {
            db = new QL_NhaTroDbContext();
        }

        public List<ModelsMVC.Framework.ChuTro> ListChuTro()
        {
            return db.ChuTroes.ToList();
        }
    }
}