using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIAppQuanLyTaiChinh.Models;

public partial class AppquanlytaichinhContext : DbContext
{
    public AppquanlytaichinhContext()
    {
    }

    public AppquanlytaichinhContext(DbContextOptions<AppquanlytaichinhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Khoanthuchi> Khoanthuchis { get; set; }

    public virtual DbSet<Nguoidung> Nguoidungs { get; set; }

    public virtual DbSet<Thuchi> Thuchis { get; set; }

    public virtual DbSet<Tiente> Tientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-681BB00;Database=appquanlytaichinh;Trusted_Connection=True;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoanthuchi>(entity =>
        {
            entity.HasKey(e => e.Idkhoangthuchi).HasName("PK__KHOANTHU__270C7FAD725C6A8C");

            entity.ToTable("KHOANTHUCHI");

            entity.Property(e => e.Idkhoangthuchi)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IDKHOANGTHUCHI");
            entity.Property(e => e.Hinhanh)
                .HasMaxLength(50)
                .HasColumnName("HINHANH");
            entity.Property(e => e.Idnguoidung)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IDNGUOIDUNG");
            entity.Property(e => e.Tenthuchi)
                .HasMaxLength(50)
                .HasColumnName("TENTHUCHI");

            entity.HasOne(d => d.IdnguoidungNavigation).WithMany(p => p.Khoanthuchis)
                .HasForeignKey(d => d.Idnguoidung)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__KHOANTHUC__IDNGU__398D8EEE");
        });

        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.Idnguoidung).HasName("PK__NGUOIDUN__9BAC50E0ADFFC5F8");

            entity.ToTable("NGUOIDUNG");

            entity.Property(e => e.Idnguoidung)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IDNGUOIDUNG");
            entity.Property(e => e.Anhdaidien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ANHDAIDIEN");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.Ngaybatdau).HasColumnName("NGAYBATDAU");
            entity.Property(e => e.Ngayketthuc).HasColumnName("NGAYKETTHUC");
            entity.Property(e => e.Passw)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PASSW");
            entity.Property(e => e.Tennguoidung)
                .HasMaxLength(50)
                .HasColumnName("TENNGUOIDUNG");
        });

        modelBuilder.Entity<Thuchi>(entity =>
        {
            entity.HasKey(e => new { e.Idkhoangthuchi, e.Idthoigianthem }).HasName("PK__THUCHI__4541B2D43EC6D18A");

            entity.ToTable("THUCHI");

            entity.Property(e => e.Idkhoangthuchi)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IDKHOANGTHUCHI");
            entity.Property(e => e.Idthoigianthem).HasColumnName("IDTHOIGIANTHEM");
            entity.Property(e => e.Sotien)
                .HasColumnType("money")
                .HasColumnName("SOTIEN");

            entity.HasOne(d => d.IdkhoangthuchiNavigation).WithMany(p => p.Thuchis)
                .HasForeignKey(d => d.Idkhoangthuchi)
                .HasConstraintName("FK__THUCHI__IDKHOANG__3C69FB99");
        });

        modelBuilder.Entity<Tiente>(entity =>
        {
            entity.HasKey(e => e.Idtiente).HasName("PK__TIENTE__0D85272E0CBDE362");

            entity.ToTable("TIENTE");

            entity.Property(e => e.Idtiente)
                .ValueGeneratedNever()
                .HasColumnName("IDTIENTE");
            entity.Property(e => e.Kihieu)
                .HasMaxLength(10)
                .HasColumnName("KIHIEU");
            entity.Property(e => e.Tendonvitiente)
                .HasMaxLength(50)
                .HasColumnName("TENDONVITIENTE");
            entity.Property(e => e.Tigiasovoivnd)
                .HasColumnType("money")
                .HasColumnName("TIGIASOVOIVND");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
