using System;
using System.Collections.Generic;
using CVWEB.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CVWEB.Models
{
    public partial class CV_WEBContext : DbContext
    {
        public CV_WEBContext()
        {
        }

        public CV_WEBContext(DbContextOptions<CV_WEBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBlog> TblBlog { get; set; } = null!;
        public virtual DbSet<TblCalisma> TblCalisma { get; set; } = null!;
        public virtual DbSet<TblHakkimda> TblHakkimda { get; set; } = null!;
        public virtual DbSet<TblHizmet> TblHizmet { get; set; } = null!;
        public virtual DbSet<TblKategori> TblKategori { get; set; } = null!;
        public virtual DbSet<TblMusteri> TblMusteri { get; set; } = null!;
        public  virtual DbSet<ViewCalismalar> ViewCalismalar { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SEHRIBANS\\MSSQLSERVER01;Database=CV_WEB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBlog>(entity =>
            {
                entity.ToTable("TBL_BLOG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(2000)
                    .HasColumnName("ACIKLAMA");

                entity.Property(e => e.Ad)
                    .HasMaxLength(50)
                    .HasColumnName("AD");

                entity.Property(e => e.Gorsel)
                    .HasMaxLength(150)
                    .HasColumnName("GORSEL");

                entity.Property(e => e.Yazar).HasColumnName("Yazar");

                entity.Property(e => e.OlusturmaTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("OLUSTURMA_TARIHI");
            });

            modelBuilder.Entity<TblCalisma>(entity =>
            {
                entity.ToTable("TBL_CALISMA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .HasColumnName("ACIKLAMA");

                entity.Property(e => e.CalismaAdi)
                    .HasMaxLength(50)
                    .HasColumnName("CALISMA_ADI");

                entity.Property(e => e.Gorsel)
                    .HasMaxLength(150)
                    .HasColumnName("GORSEL");

                entity.Property(e => e.Kategori).HasColumnName("KATEGORI");
            });

            modelBuilder.Entity<TblHakkimda>(entity =>
            {
                entity.ToTable("TBL_HAKKIMDA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdSoyad)
                    .HasMaxLength(150)
                    .HasColumnName("AD_SOYAD");

                entity.Property(e => e.Adres)
                    .HasMaxLength(200)
                    .HasColumnName("ADRES");

                entity.Property(e => e.Eposta)
                    .HasMaxLength(150)
                    .HasColumnName("EPOSTA");

                entity.Property(e => e.Gorsel)
                    .HasMaxLength(200)
                    .HasColumnName("GORSEL");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(50)
                    .HasColumnName("TELEFON");
                entity.Property(e => e.Aciklama)
                   .HasMaxLength(1000)
                   .HasColumnName("ACIKLAMA");
            });

            modelBuilder.Entity<TblHizmet>(entity =>
            {
                entity.ToTable("TBL_HIZMET");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .HasColumnName("ACIKLAMA");

                entity.Property(e => e.Gorsel)
                    .HasMaxLength(150)
                    .HasColumnName("GORSEL");

                entity.Property(e => e.HizmetAdi)
                    .HasMaxLength(50)
                    .HasColumnName("HIZMET_ADI");
            });

            modelBuilder.Entity<TblKategori>(entity =>
            {
                entity.ToTable("TBL_KATEGORI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KategoriAd)
                    .HasMaxLength(10)
                    .HasColumnName("KATEGORI_AD")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblMusteri>(entity =>
            {
                entity.ToTable("TBL_MUSTERI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdSoyad)
                    .HasMaxLength(150)
                    .HasColumnName("AD_SOYAD");

               

                entity.Property(e => e.Eposta)
                    .HasMaxLength(100)
                    .HasColumnName("EPOSTA");

                entity.Property(e => e.KayitTarİhİ)
                    .HasColumnType("datetime")
                    .HasColumnName("KAYIT_TARİHİ");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(50)
                    .HasColumnName("TELEFON");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
