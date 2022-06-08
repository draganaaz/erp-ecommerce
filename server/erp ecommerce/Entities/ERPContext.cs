using System;
using JWTAuthentication.Authentication;
using Microsoft.EntityFrameworkCore;

namespace erp_ecommerce.Entities
{
    public partial class ERPContext : DbContext
    {

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductColors> ProductColors { get; set; }
        public virtual DbSet<ProductSizes> ProductSizes { get; set; }
        public virtual DbSet<Size> Size { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ERP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand", "shop");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnName("BrandName")
                    .HasMaxLength(50);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "shop");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("CategoryName")
                    .HasMaxLength(50);

                entity.Property(e => e.Image)
                   .IsRequired()
                   .HasMaxLength(500);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color", "shop");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.ColorName)
                    .IsRequired()
                    .HasColumnName("ColorName")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_Order");

                entity.ToTable("Orders", "shop");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.IsPaymentDone).HasColumnName("isPaymentDone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TotalPrice).HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "shop");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ProductColorId).HasColumnName("ProductColorID");

                entity.Property(e => e.ProductSizeId).HasColumnName("ProductSizeID");

                entity.Property(e => e.ProductType).HasMaxLength(10);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<ProductColors>(entity =>
            {
                entity.HasKey(e => e.ProductColorId);

                entity.ToTable("ProductColors", "shop");

                entity.Property(e => e.ProductColorId).HasColumnName("ProductColorID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_ProductColors_Color");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductColors_Product");
            });

            modelBuilder.Entity<ProductSizes>(entity =>
            {
                entity.HasKey(e => e.ProductSizeId);

                entity.ToTable("ProductSizes", "shop");

                entity.Property(e => e.ProductSizeId).HasColumnName("ProductSizeID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductSizes_Product");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_ProductSizes_Size");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size", "shop");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.SizeName)
                    .IsRequired()
                    .HasColumnName("SizeName")
                    .HasMaxLength(5);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
