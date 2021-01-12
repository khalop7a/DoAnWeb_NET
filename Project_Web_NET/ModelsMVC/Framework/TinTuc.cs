namespace ModelsMVC.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        public int TinTuc_ID { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống!")]
        [StringLength(255, ErrorMessage = "Tiêu đề không được quá 255 ký tự!")]
        public string TieuDe { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayChinhSua { get; set; }

        public int? Phong_ID { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
