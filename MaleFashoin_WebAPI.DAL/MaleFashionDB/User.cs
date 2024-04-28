using System;
using System.Collections.Generic;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class User
{
    public byte[] Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public byte[]? AddressId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Dob { get; set; }

    public short? Gender { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public byte[]? RoleId { get; set; }

    public short? Status { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<Contact> Contacts { get; } = new List<Contact>();

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<ProductReview> ProductReviews { get; } = new List<ProductReview>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<WishList> WishLists { get; } = new List<WishList>();
}
