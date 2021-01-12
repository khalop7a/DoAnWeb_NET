namespace ModelsMVC.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGia")]
    public partial class DanhGia
    {
        [Key]

        public int DanhGia_ID { get; set; }

        [StringLength(100)]
        public string NguoiDung_ID { get; set; }

        public int? Phong_ID { get; set; }

        [Required(ErrorMessage = "Nội dung chưa hợp lệ!")]
        public string NoiDung { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
