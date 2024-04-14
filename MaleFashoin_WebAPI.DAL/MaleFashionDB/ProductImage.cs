using System;
using System.Collections.Generic;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class ProductImage
{
    public byte[] ImageId { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public byte[] ProductId { get; set; } = null!;

    public bool DefaultImage { get; set; }

    public virtual Product Product { get; set; } = null!;
}
