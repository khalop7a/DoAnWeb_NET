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
    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        private QL_NhaTroDbContext context = null;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
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
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login_ND @UserName, @Password", sqlParas).SingleOrDefault();
            return res;
        }

        [Key]
        [StringLength(100)]
        public string NguoiDung_ID { get; set; }

        [Required]
        [StringLength(32)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        public bool? GioiTinh { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        public string DiaChi { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        [NotMapped]
        public bool? Rememberme { get; set; }
    }
}
