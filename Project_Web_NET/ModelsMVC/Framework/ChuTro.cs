namespace ModelsMVC.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("ChuTro")]
    public partial class ChuTro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuTro()
        {
            Phongs = new HashSet<Phong>();
        }

        [Key]
        [Display(Name = "Tên đăng nhập")]
        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Chiều dài ít nhất 6 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập!")]
        [Remote("TrungTaiKhoan_ChuTro", "DangKy", HttpMethod = "POST", ErrorMessage = "Tên đăng nhập đã tồn tại!")]
        public string ChuTro_ID { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string MatKhau { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu!")]
        [System.ComponentModel.DataAnnotations.Compare("MatKhau", ErrorMessage = "Nhập lại mật khẩu không đúng!")]
        [Display(Name = "Nhập lại mật khẩu")]
        [NotMapped]
        public string NhapLaiMatKhau { get; set; }

        [Required(ErrorMessage = "Email chưa hợp lệ!")]
        [Display(Name = "Địa chỉ Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
        [StringLength(320, ErrorMessage = "Độ dài chuỗi không quá 320 ký tự")]
        [Remote("TrungEmail_ChuTro", "DangKy", HttpMethod = "POST", ErrorMessage = "Địa chỉ email đã được sử dụng!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Số điện thoại chưa hợp lệ!")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Số điện thoại")]
        //^(0*0-9+,9,10-)$
        [RegularExpression("0[0-9]{9}", ErrorMessage = "Số điện thoại phải có 10 số!")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Tên nhà trọ chưa hợp lệ!")]
        [Display(Name = "Tên nhà trọ")]
        [StringLength(255)]
        public string TenNhaTro { get; set; }

        [Required(ErrorMessage = "Địa chỉ chưa hợp lệ!")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
