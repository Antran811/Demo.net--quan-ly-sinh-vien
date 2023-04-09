using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace test117.TestModels
{
    public partial class QLSinhVienContext : DbContext
    {
        public QLSinhVienContext()
        {
        }

        public QLSinhVienContext(DbContextOptions<QLSinhVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IJJR4JL\\SQLEXPRESS01;Initial Catalog=QLSinhVien;Integrated Security =True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.Masv);

                entity.ToTable("Sinh_Vien");

                entity.Property(e => e.Masv)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Diemtb).HasColumnName("diemtb");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(50)
                    .HasColumnName("gioitinh");

                entity.Property(e => e.Khoa)
                    .HasMaxLength(50)
                    .HasColumnName("khoa");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Tensv).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
