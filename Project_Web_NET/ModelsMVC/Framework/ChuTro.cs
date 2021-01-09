namespace ModelsMVC.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuTro")]
    public partial class ChuTro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuTro()
        {
            Phongs = new HashSet<Phong>();
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
    }
}
