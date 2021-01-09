using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelsMVC.Framework
{
    public partial class QL_NhaTroDbContext : DbContext
    {
        public QL_NhaTroDbContext()
            : base("name=QL_NhaTroDbContext")
        {
        }

        public virtual DbSet<ChuTro> ChuTroes { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuTro>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<ChuTro>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ChuTro>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
