using ModelsMVC.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMVC
{
    public class DanhGiaModel
    {
        QL_NhaTroDbContext db = null;
        public DanhGiaModel()
        {
            db = new QL_NhaTroDbContext();
        }

        public IEnumerable<DanhGia> ListAllPage(int page, int rowLimit)
        {
            return db.DanhGias.OrderByDescending(x => x.DanhGia_ID).ToPagedList(page, rowLimit);
        }
    }
}
