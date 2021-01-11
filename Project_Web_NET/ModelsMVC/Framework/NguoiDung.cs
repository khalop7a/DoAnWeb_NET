using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Web.Mvc;

namespace ModelsMVC.Framework
{
    [Table("NguoiDung")]
    public partial class NguoiDung
    {
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

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên!")]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính!")]
        public bool? GioiTinh { get; set; }

        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại!")]
        [StringLength(10)]
        public string SDT { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ!")]
        public string DiaChi { get; set; }

        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ Email!")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
        [Remote("TrungEmail_NguoiDung", "DangKy", HttpMethod = "POST", ErrorMessage = "Địa chỉ email đã được sử dụng!")]
        [StringLength(320)]
        public string Email { get; set; }

        public virtual ICollection<DanhGia> DanhGias { get; set; }
    }
}
