﻿namespace ModelsMVC.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            DanhGias = new HashSet<DanhGia>();
            TinTucs = new HashSet<TinTuc>();
        }

        [Key]

        public int Phong_ID { get; set; }

        public int? LoaiPhong_ID { get; set; }

        [StringLength(100)]
        public string ChuTro_ID { get; set; }

        [Required(ErrorMessage = "Diện tích không được để trống!")]
        [StringLength(100, ErrorMessage = "Diện tích không được quá 100 ký tự!")]
        public string DienTich { get; set; }

        [Range(0, 10000000, ErrorMessage = "Giá không được nhỏ hơn 0 và lớn hơn 10000000!")]
        public double Gia { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        public string DiaChi { get; set; }

        public string MoTa { get; set; }

        [Required(ErrorMessage = "Số lượng chưa hợp lệ!")]
        [Range(0, 1000, ErrorMessage = "Số lượng không được nhỏ hơn 0 và lớn hơn 1000!")]
        public int? SoLuong { get; set; }

        public string HinhAnh { get; set; }

        public virtual ChuTro ChuTro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TinTuc> TinTucs { get; set; }
    }
}
