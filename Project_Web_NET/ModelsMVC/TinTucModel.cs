using ModelsMVC.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMVC
{
    public class TinTucModel
    {
        QL_NhaTroDbContext db = null;
        public TinTucModel()
        {
            db = new QL_NhaTroDbContext();
        }

        public IEnumerable<TinTuc> ListAllPage(int page, int rowLimit)
        {
            return db.TinTucs.OrderByDescending(x => x.TinTuc_ID).ToPagedList(page, rowLimit);
        }
    }
}
