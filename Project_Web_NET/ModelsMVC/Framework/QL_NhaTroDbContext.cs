namespace ModelsMVC.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QL_NhaTroDbContext : DbContext
    {
        public QL_NhaTroDbContext()
            : base("name=QL_NhaTroDbContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ChuTro> ChuTroes { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Email)
                .IsUnicode(false);

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
