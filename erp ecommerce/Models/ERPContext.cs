using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace erp_ecommerce.Models
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
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductColors> ProductColors { get; set; }
        public virtual DbSet<ProductSizes> ProductSizes { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }
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

                entity.Property(e => e.BrandId)
                    .HasColumnName("BrandID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Brand1)
                    .IsRequired()
                    .HasColumnName("Brand")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "shop");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Category1)
                    .IsRequired()
                    .HasColumnName("Category")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color", "shop");

                entity.Property(e => e.ColorId)
                    .HasColumnName("ColorID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Color1)
                    .IsRequired()
                    .HasColumnName("Color")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("OrderDetails", "shop");

                entity.Property(e => e.OrderDetailsId)
                    .HasColumnName("OrderDetailsID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Quantity).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Subtotal).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.UnitCost).HasColumnType("numeric(6, 3)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetails_Product");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_Order");

                entity.ToTable("Orders", "shop");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateShipped).HasColumnType("datetime");

                entity.Property(e => e.OrderDetailsId)
                    .HasColumnName("OrderDetailsID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ShippingId)
                    .HasColumnName("ShippingID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Users");

                entity.HasOne(d => d.OrderDetails)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderDetailsId)
                    .HasConstraintName("FK_Order_OrderDetails");

                entity.HasOne(d => d.Shipping)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShippingId)
                    .HasConstraintName("FK_Order_Shipping");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price", "shop");

                entity.Property(e => e.PriceId)
                    .HasColumnName("PriceID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Discount).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Price1)
                    .HasColumnName("Price")
                    .HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "shop");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BrandId)
                    .HasColumnName("BrandID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PriceId)
                    .HasColumnName("PriceID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ProductColorId)
                    .HasColumnName("ProductColorID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ProductSizeId)
                    .HasColumnName("ProductSizeID")
                    .HasColumnType("numeric(10, 0)");

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

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Product_Price");

                entity.HasOne(d => d.ProductColor)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductColorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Product_ProductColors");

                entity.HasOne(d => d.ProductSize)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductSizeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Product_ProductSizes");
            });

            modelBuilder.Entity<ProductColors>(entity =>
            {
                entity.HasKey(e => e.ProductColorId);

                entity.ToTable("ProductColors", "shop");

                entity.Property(e => e.ProductColorId)
                    .HasColumnName("ProductColorID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ColorId)
                    .HasColumnName("ColorID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_ProductColors_Color");
            });

            modelBuilder.Entity<ProductSizes>(entity =>
            {
                entity.HasKey(e => e.ProductSizeId);

                entity.ToTable("ProductSizes", "shop");

                entity.Property(e => e.ProductSizeId)
                    .HasColumnName("ProductSizeID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.SizeId)
                    .HasColumnName("SizeID")
                    .HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_ProductSizes_Size");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.ToTable("Shipping", "shop");

                entity.Property(e => e.ShippingId)
                    .HasColumnName("ShippingID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ShippingCost)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ShippingRegion)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ShippingType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size", "shop");

                entity.Property(e => e.SizeId)
                    .HasColumnName("SizeID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

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

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

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
