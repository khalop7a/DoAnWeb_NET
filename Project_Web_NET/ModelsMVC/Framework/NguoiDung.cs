namespace ModelsMVC.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            DanhGias = new HashSet<DanhGia>();
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
    }
}
