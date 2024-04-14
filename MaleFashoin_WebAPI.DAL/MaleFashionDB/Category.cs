using System;
using System.Collections.Generic;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class Category
{
    public byte[] CategoryId { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string CategoryImgUrl { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual ICollection<SubCategory> SubCategories { get; } = new List<SubCategory>();
}
