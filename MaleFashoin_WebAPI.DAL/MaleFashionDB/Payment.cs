using System;
using System.Collections.Generic;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class Payment
{
    public byte[] PaymentId { get; set; } = null!;

    public byte[] UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string CardNo { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PaymentMode { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual User User { get; set; } = null!;
}
