using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CDClassLibrary.Models
{
    public partial class CdContext : DbContext
    {
        public CdContext()
        {
        }

        public CdContext(DbContextOptions<CdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cd> Cd { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Dbeli> Dbeli { get; set; }
        public virtual DbSet<Dpjmcd> Dpjmcd { get; set; }
        public virtual DbSet<Hbeli> Hbeli { get; set; }
        public virtual DbSet<Hpjmcd> Hpjmcd { get; set; }
        public virtual DbSet<Jeniscd> Jeniscd { get; set; }
        public virtual DbSet<Paket> Paket { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Trpaket> Trpaket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = orcl)));User id=admin;Password=admin;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:DefaultSchema", "ADMIN");

            modelBuilder.Entity<Cd>(entity =>
            {
                entity.HasKey(e => e.Kodecd)
                    .HasName("SYS_C0011087");

                entity.ToTable("CD");

                entity.HasIndex(e => e.Kodecd)
                    .HasName("SYS_C0011087")
                    .IsUnique();

                entity.Property(e => e.Kodecd)
                    .HasColumnName("KODECD")
                    .HasColumnType("VARCHAR2(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Hrgsewa).HasColumnName("HRGSEWA");

                entity.Property(e => e.Judulcd)
                    .HasColumnName("JUDULCD")
                    .HasColumnType("VARCHAR2(20)");

                entity.Property(e => e.Lamasw)
                    .HasColumnName("LAMASW")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasColumnType("VARCHAR2(1)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Kodecust)
                    .HasName("SYS_C0011084");

                entity.ToTable("CUSTOMER");

                entity.HasIndex(e => e.Kodecust)
                    .HasName("SYS_C0011084")
                    .IsUnique();

                entity.Property(e => e.Kodecust)
                    .HasColumnName("KODECUST")
                    .HasColumnType("VARCHAR2(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasColumnName("ALAMAT")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.Nama)
                    .HasColumnName("NAMA")
                    .HasColumnType("VARCHAR2(20)");

                entity.Property(e => e.Telp)
                    .HasColumnName("TELP")
                    .HasColumnType("VARCHAR2(10)");
            });

            modelBuilder.Entity<Dbeli>(entity =>
            {
                entity.HasKey(e => new { e.Notabeli, e.Kodecd })
                    .HasName("SYS_C0011098");

                entity.ToTable("DBELI");

                entity.HasIndex(e => new { e.Notabeli, e.Kodecd })
                    .HasName("SYS_C0011098")
                    .IsUnique();

                entity.Property(e => e.Notabeli)
                    .HasColumnName("NOTABELI")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.Kodecd)
                    .HasColumnName("KODECD")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.Harga).HasColumnName("HARGA");

                entity.Property(e => e.Jumlah).HasColumnName("JUMLAH");

                entity.HasOne(d => d.KodecdNavigation)
                    .WithMany(p => p.Dbeli)
                    .HasForeignKey(d => d.Kodecd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0011100");

                entity.HasOne(d => d.NotabeliNavigation)
                    .WithMany(p => p.Dbeli)
                    .HasForeignKey(d => d.Notabeli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0011099");
            });

            modelBuilder.Entity<Dpjmcd>(entity =>
            {
                entity.HasKey(e => new { e.Notapjm, e.Kodecd });

                entity.ToTable("DPJMCD");

                entity.HasIndex(e => new { e.Notapjm, e.Kodecd })
                    .HasName("PK_DPJMCD")
                    .IsUnique();

                entity.Property(e => e.Notapjm)
                    .HasColumnName("NOTAPJM")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.Kodecd)
                    .HasColumnName("KODECD")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.Kodetp)
                    .HasColumnName("KODETP")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.Subtotal).HasColumnName("SUBTOTAL");

                entity.Property(e => e.Tglkembali)
                    .HasColumnName("TGLKEMBALI")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.KodecdNavigation)
                    .WithMany(p => p.Dpjmcd)
                    .HasForeignKey(d => d.Kodecd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0011094");

                entity.HasOne(d => d.KodetpNavigation)
                    .WithMany(p => p.Dpjmcd)
                    .HasForeignKey(d => d.Kodetp)
                    .HasConstraintName("SYS_C0011095");

                entity.HasOne(d => d.NotapjmNavigation)
                    .WithMany(p => p.Dpjmcd)
                    .HasForeignKey(d => d.Notapjm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTAPJM_DPJMCD");
            });

            modelBuilder.Entity<Hbeli>(entity =>
            {
                entity.HasKey(e => e.Notabeli)
                    .HasName("SYS_C0011096");

                entity.ToTable("HBELI");

                entity.HasIndex(e => e.Notabeli)
                    .HasName("SYS_C0011096")
                    .IsUnique();

                entity.Property(e => e.Notabeli)
                    .HasColumnName("NOTABELI")
                    .HasColumnType("VARCHAR2(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Kodesup)
                    .HasColumnName("KODESUP")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.Tanggal)
                    .HasColumnName("TANGGAL")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.KodesupNavigation)
                    .WithMany(p => p.Hbeli)
                    .HasForeignKey(d => d.Kodesup)
                    .HasConstraintName("SYS_C0011097");
            });

            modelBuilder.Entity<Hpjmcd>(entity =>
            {
                entity.HasKey(e => e.Notapjm)
                    .HasName("SYS_C0011092");

                entity.ToTable("HPJMCD");

                entity.HasIndex(e => e.Notapjm)
                    .HasName("SYS_C0011092")
                    .IsUnique();

                entity.Property(e => e.Notapjm)
                    .HasColumnName("NOTAPJM")
                    .HasColumnType("VARCHAR2(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Kodecust)
                    .HasColumnName("KODECUST")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.Tanggal)
                    .HasColumnName("TANGGAL")
                    .HasColumnType("DATE");

                entity.Property(e => e.Total).HasColumnName("TOTAL");

                entity.HasOne(d => d.KodecustNavigation)
                    .WithMany(p => p.Hpjmcd)
                    .HasForeignKey(d => d.Kodecust)
                    .HasConstraintName("SYS_C0011093");
            });

            modelBuilder.Entity<Jeniscd>(entity =>
            {
                entity.HasKey(e => e.Kodejns)
                    .HasName("SYS_C0011086");

                entity.ToTable("JENISCD");

                entity.HasIndex(e => e.Kodejns)
                    .HasName("SYS_C0011086")
                    .IsUnique();

                entity.Property(e => e.Kodejns)
                    .HasColumnName("KODEJNS")
                    .HasColumnType("VARCHAR2(1)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Namajns)
                    .HasColumnName("NAMAJNS")
                    .HasColumnType("VARCHAR2(15)");
            });

            modelBuilder.Entity<Paket>(entity =>
            {
                entity.HasKey(e => e.Kodepk)
                    .HasName("SYS_C0011088");

                entity.ToTable("PAKET");

                entity.HasIndex(e => e.Kodepk)
                    .HasName("SYS_C0011088")
                    .IsUnique();

                entity.Property(e => e.Kodepk)
                    .HasColumnName("KODEPK")
                    .HasColumnType("VARCHAR2(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Harga)
                    .HasColumnName("HARGA")
                    .HasColumnType("NUMBER(7)");

                entity.Property(e => e.Jumlah).HasColumnName("JUMLAH");

                entity.Property(e => e.Nama)
                    .HasColumnName("NAMA")
                    .HasColumnType("VARCHAR2(20)");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Kodesup)
                    .HasName("SYS_C0011085");

                entity.ToTable("SUPPLIER");

                entity.HasIndex(e => e.Kodesup)
                    .HasName("SYS_C0011085")
                    .IsUnique();

                entity.Property(e => e.Kodesup)
                    .HasColumnName("KODESUP")
                    .HasColumnType("VARCHAR2(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasColumnName("ALAMAT")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.Nama)
                    .HasColumnName("NAMA")
                    .HasColumnType("VARCHAR2(20)");

                entity.Property(e => e.Telp)
                    .HasColumnName("TELP")
                    .HasColumnType("VARCHAR2(10)");
            });

            modelBuilder.Entity<Trpaket>(entity =>
            {
                entity.HasKey(e => e.Kodetp)
                    .HasName("SYS_C0011089");

                entity.ToTable("TRPAKET");

                entity.HasIndex(e => e.Kodetp)
                    .HasName("SYS_C0011089")
                    .IsUnique();

                entity.Property(e => e.Kodetp)
                    .HasColumnName("KODETP")
                    .HasColumnType("VARCHAR2(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Kodecust)
                    .HasColumnName("KODECUST")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.Kodepk)
                    .HasColumnName("KODEPK")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.Sisa).HasColumnName("SISA");

                entity.HasOne(d => d.KodecustNavigation)
                    .WithMany(p => p.Trpaket)
                    .HasForeignKey(d => d.Kodecust)
                    .HasConstraintName("SYS_C0011090");

                entity.HasOne(d => d.KodepkNavigation)
                    .WithMany(p => p.Trpaket)
                    .HasForeignKey(d => d.Kodepk)
                    .HasConstraintName("SYS_C0011091");
            });
        }
    }
}
