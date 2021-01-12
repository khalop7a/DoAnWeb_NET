namespace ModelsMVC.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [StringLength(50)]
        public string id { get; set; }

        [Required]
        [StringLength(32)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }
    }
}
