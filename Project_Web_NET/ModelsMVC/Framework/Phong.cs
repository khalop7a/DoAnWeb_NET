namespace ModelsMVC.Framework
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

        [Required]
        [StringLength(100)]
        public string DienTich { get; set; }

        public double Gia { get; set; }

        [Required]
        public string DiaChi { get; set; }

        public string MoTa { get; set; }

        public int? SoLuong { get; set; }

        public virtual ChuTro ChuTro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TinTuc> TinTucs { get; set; }
    }
}
