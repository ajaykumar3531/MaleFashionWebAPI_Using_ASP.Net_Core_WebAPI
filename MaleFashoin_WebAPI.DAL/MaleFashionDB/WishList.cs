using System;
using System.Collections.Generic;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class WishList
{
    public byte[] WishListId { get; set; } = null!;

    public byte[] ProductId { get; set; } = null!;

    public byte[] UserId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
