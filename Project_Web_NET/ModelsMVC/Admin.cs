using ModelsMVC.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMVC
{
    [Table("Admin")]
    public partial class Admin
    {
        private QL_NhaTroDbContext context = null;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            context = new QL_NhaTroDbContext();
        }

        public bool Login(string userName, string Password)
        {
            object[] sqlParas = {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", Password),
            };
            //Gọi thủ tục đã tạo có tên "Sp_Account_Login" sử dụng SingleOrDefault() để trả về giá trị duy nhất, 
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login_Admin @UserName, @Password", sqlParas).SingleOrDefault();
            return res;
        }

        [StringLength(50)]
        public string id { get; set; }

        [Required]
        [StringLength(32)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }
        public Boolean Remenberme { set; get; }
    }

}
