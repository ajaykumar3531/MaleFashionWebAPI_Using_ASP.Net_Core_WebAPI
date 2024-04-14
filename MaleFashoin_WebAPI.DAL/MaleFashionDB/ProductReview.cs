using System;
using System.Collections.Generic;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class ProductReview
{
    public byte[] ReviewId { get; set; } = null!;

    public int Rating { get; set; }

    public string Comment { get; set; } = null!;

    public byte[] ProductId { get; set; } = null!;

    public byte[] UserId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
