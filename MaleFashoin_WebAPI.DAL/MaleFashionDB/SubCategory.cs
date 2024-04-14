using System;
using System.Collections.Generic;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class SubCategory
{
    public byte[] SubCategoryId { get; set; } = null!;

    public string SubCategoryName { get; set; } = null!;

    public byte[] CategoryId { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
