using System;
using System.Collections.Generic;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class Cart
{
    public byte[] CartId { get; set; } = null!;

    public byte[] ProductId { get; set; } = null!;

    public int Quantity { get; set; }

    public byte[] UserId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
