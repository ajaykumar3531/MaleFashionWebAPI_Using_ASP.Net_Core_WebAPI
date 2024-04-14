using System;
using System.Collections.Generic;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class Product
{
    public byte[] ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public string Longdescription { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string Size { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public byte[] CategoryId { get; set; } = null!;

    public byte[] SubCategoryId { get; set; } = null!;

    public int Sold { get; set; }

    public bool IsCustomized { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual ICollection<ProductImage> ProductImages { get; } = new List<ProductImage>();

    public virtual ICollection<ProductReview> ProductReviews { get; } = new List<ProductReview>();

    public virtual SubCategory SubCategory { get; set; } = null!;

    public virtual ICollection<WishList> WishLists { get; } = new List<WishList>();
}
