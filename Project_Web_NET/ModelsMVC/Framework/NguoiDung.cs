namespace ModelsMVC.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            DanhGias = new HashSet<DanhGia>();
        }

        [Key]
        [Required(ErrorMessage = "Vui lòng nhập số tên đăng nhập!")]
        [Display(Name = "Tên đăng nhập")]
        [StringLength(maximumLength: 100, MinimumLength = 6, ErrorMessage = "Chiều dài ít nhất 6 ký tự")]
        [Remote("TrungTaiKhoan_NguoiDung", "DangKy", HttpMethod = "POST", ErrorMessage = "Tên đăng nhập đã tồn tại!")]
        public string NguoiDung_ID { get; set; }


        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        public string MatKhau { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu!")]
        [System.ComponentModel.DataAnnotations.Compare("MatKhau", ErrorMessage = "Nhập lại mật khẩu không đúng!")]
        [NotMapped]
        public string NhapLaiMatKhau { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống!")]
        [Display(Name = "Họ tên")]
        [StringLength(100, ErrorMessage = "Tên người dùng không quá 100 ký tự!")]
        public string HoTen { get; set; }

        [Display(Name = "Giới tính")]
        public bool? GioiTinh { get; set; }

        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [RegularExpression("0[0-9]{9}", ErrorMessage = "Số điện thoại phải có 10 số!")]

        public string SDT { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Email không được để trống!")]
        [Display(Name = "Địa chỉ Email")]
        [StringLength(320, ErrorMessage = "Email không quá 320 ký tự!")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
        [Remote("TrungEmail_NguoiDung", "DangKy", HttpMethod = "POST", ErrorMessage = "Địa chỉ email đã được sử dụng!")]

        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        [NotMapped]
        public bool? Rememberme { get; set; }

    }
}
