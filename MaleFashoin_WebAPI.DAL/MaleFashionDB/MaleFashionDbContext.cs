using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class MaleFashionDbContext : DbContext
{
    public MaleFashionDbContext()
    {
    }

    public MaleFashionDbContext(DbContextOptions<MaleFashionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductReview> ProductReviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HGT-LAP-371;Database=MaleFashionDB;User Id=sa;Password=Hallmark123;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3214EC272556C080");

            entity.ToTable("Address");

            entity.Property(e => e.Id)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.City).IsUnicode(false);
            entity.Property(e => e.Country).IsUnicode(false);
            entity.Property(e => e.CountryCode).IsUnicode(false);
            entity.Property(e => e.LandMark).IsUnicode(false);
            entity.Property(e => e.State).IsUnicode(false);
            entity.Property(e => e.StatePinCode).IsUnicode(false);
            entity.Property(e => e.Street).IsUnicode(false);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD797304BFF83");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("CartID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.UserId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__ProductID__49C3F6B7");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__UserID__4AB81AF0");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B5D8C4316");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryImgUrl).IsUnicode(false);
            entity.Property(e => e.CategoryName).IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C6625BBB714DC3C");

            entity.ToTable("Contact");

            entity.Property(e => e.ContactId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("ContactID");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Message).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Subject).IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contact__UserID__4D94879B");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C800D96AF");

            entity.Property(e => e.OrderDetailId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(18)
                .IsFixedLength();
            entity.Property(e => e.PaymentId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("PaymentID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.Payment).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Payme__571DF1D5");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__5535A963");

            entity.HasOne(d => d.User).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__UserI__5629CD9C");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A58BB6829D9");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("PaymentID");
            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.CardNo).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.PaymentMode).IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__UserID__5070F446");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED30C92A99");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("CategoryID");
            entity.Property(e => e.Color).IsUnicode(false);
            entity.Property(e => e.CompanyName).IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Longdescription)
                .IsUnicode(false)
                .HasColumnName("LONGDescription");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).IsUnicode(false);
            entity.Property(e => e.ShortDescription).IsUnicode(false);
            entity.Property(e => e.Size).IsUnicode(false);
            entity.Property(e => e.SubCategoryId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("SubCategoryID");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Categor__2E1BDC42");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__SubCate__2F10007B");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__ProductI__7516F4ECD9EFB900");

            entity.Property(e => e.ImageId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("ImageID");
            entity.Property(e => e.ImageUrl)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.ProductId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImages_ProductID");
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__ProductR__74BC79AED7AFCE63");

            entity.ToTable("ProductReview");

            entity.Property(e => e.ReviewId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("ReviewID");
            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.UserId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductRe__Produ__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductRe__UserI__412EB0B6");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AD9450F65");

            entity.Property(e => e.RoleId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName).IsUnicode(false);
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryId).HasName("PK__SubCateg__26BE5BF9611C6D54");

            entity.ToTable("SubCategory");

            entity.Property(e => e.SubCategoryId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("SubCategoryID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SubCategoryName).IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubCatego__Categ__2A4B4B5E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC274C1731AB");

            entity.Property(e => e.Id)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.AddressId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("AddressID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dob)
                .IsUnicode(false)
                .HasColumnName("DOB");
            entity.Property(e => e.FirstName)
                .IsUnicode(false)
                .HasColumnName("First Name");
            entity.Property(e => e.ImageUrl)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.LastName)
                .IsUnicode(false)
                .HasColumnName("Last Name");
            entity.Property(e => e.MiddleName)
                .IsUnicode(false)
                .HasColumnName("Middle Name");
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.PhoneNumber).IsUnicode(false);
            entity.Property(e => e.RoleId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("RoleID");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            entity.Property(e => e.UserName).IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.Users)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__Users__AddressID__3B75D760");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__3C69FB99");
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.HasKey(e => e.WishListId).HasName("PK__WishList__E41F87A704EFEAC4");

            entity.ToTable("WishList");

            entity.Property(e => e.WishListId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("WishListID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.UserId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WishList__Produc__44FF419A");

            entity.HasOne(d => d.User).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WishList__UserID__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
