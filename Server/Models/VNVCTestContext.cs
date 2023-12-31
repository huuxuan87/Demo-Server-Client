﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Server.Models
{
    public partial class VNVCTestContext : DbContext
    {
        public VNVCTestContext()
        {
        }

        public VNVCTestContext(DbContextOptions<VNVCTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DatSo> DatSo { get; set; }
        public virtual DbSet<KetQua> KetQua { get; set; }
        public virtual DbSet<NguoiChoi> NguoiChoi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatSo>(entity =>
            {
                entity.Property(e => e.Ngay).HasColumnType("datetime");

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");
            });

            modelBuilder.Entity<KetQua>(entity =>
            {
                entity.HasKey(e => new { e.Ngay, e.Gio })
                    .HasName("PK__KetQua__A79D0681A867E1B4");

                entity.Property(e => e.Ngay).HasColumnType("datetime");

                entity.Property(e => e.KetQua1).HasColumnName("KetQua");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");
            });

            modelBuilder.Entity<NguoiChoi>(entity =>
            {
                entity.Property(e => e.DienThoai).HasMaxLength(10);

                entity.Property(e => e.HoDem).HasMaxLength(200);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Ten).HasMaxLength(100);
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}