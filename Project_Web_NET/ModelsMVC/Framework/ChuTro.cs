using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Net.Http;
using System.Web.Mvc;

namespace ModelsMVC.Framework
{
    [Table("ChuTro")]
    public partial class ChuTro
    {
        public ChuTro()
        {
            Phongs = new HashSet<Phong>();
        }
        [Key]
        [Display(Name ="Tên đăng nhập")]
        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Chiều dài ít nhất 6 ký tự")]
        [Required(ErrorMessage ="Vui lòng nhập tên đăng nhập!")]
        [Remote("TrungTaiKhoan_ChuTro", "DangKy", HttpMethod = "POST", ErrorMessage = "Tên đăng nhập đã tồn tại!")]
        public string ChuTro_ID { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string MatKhau { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Vui lòng nhập lại mật khẩu!")]
        [System.ComponentModel.DataAnnotations.Compare("MatKhau", ErrorMessage = "Nhập lại mật khẩu không đúng!")]
        [Display(Name = "Nhập lại mật khẩu")]
        [NotMapped]
        public string NhapLaiMatKhau { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập địa chỉ Email!")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
        [Display(Name = "Địa chỉ Email")]
        [StringLength(320)]
        [Remote("TrungEmail_ChuTro", "DangKy", HttpMethod = "POST", ErrorMessage = "Địa chỉ email đã được sử dụng!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập số điện thoại!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Số điện thoại")]
        [StringLength(11)]
        public string SDT { get; set; }

        [Display(Name = "Tên nhà trọ")]
        [Required(ErrorMessage = "Vui lòng nhập tên nhà trọ!")]
        [StringLength(255)]
        public string TenNhaTro { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập Địa chỉ!")]
        public string DiaChi { get; set; }

        public bool IsValid { get; set; }
        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
