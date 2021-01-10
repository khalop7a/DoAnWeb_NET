namespace ModelsMVC.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("ChuTro")]
    public partial class ChuTro
    {
        private QL_NhaTroDbContext context = null;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuTro()
        {
            Phongs = new HashSet<Phong>();
            context = new QL_NhaTroDbContext();
        }

        public bool Login(string userName, string Password)
        {
            object[] sqlParas = {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", Password),
            };
            //Gọi thủ tục đã tạo có tên "Sp_Account_Login" sử dụng SingleOrDefault() để trả về giá trị duy nhất, 
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login_CT @UserName, @Password", sqlParas).SingleOrDefault();
            return res;
        }


        [Key]
        [StringLength(100)]
        public string ChuTro_ID { get; set; }

        [Required]
        [StringLength(32)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [Required]
        [StringLength(255)]
        public string TenNhaTro { get; set; }

        [Required]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phong> Phongs { get; set; }
        public Boolean Remenberme { set; get; }
    }
}
