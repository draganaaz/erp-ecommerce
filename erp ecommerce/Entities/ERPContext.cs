using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace erp_ecommerce.Entities
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

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
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ERP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand", "shop");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.Brand1)
                    .IsRequired()
                    .HasColumnName("Brand")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "shop");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Category1)
                    .IsRequired()
                    .HasColumnName("Category")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color", "shop");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.Color1)
                    .IsRequired()
                    .HasColumnName("Color")
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

                entity.Property(e => e.Discount).HasColumnType("int");

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
                entity.HasKey(e => new { e.ColorId, e.ProductId });

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
                entity.HasKey(e => new { e.SizeId, e.ProductId });

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

                entity.Property(e => e.Size1)
                    .IsRequired()
                    .HasColumnName("Size")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserID");

                entity.ToTable("Users", "shop");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
