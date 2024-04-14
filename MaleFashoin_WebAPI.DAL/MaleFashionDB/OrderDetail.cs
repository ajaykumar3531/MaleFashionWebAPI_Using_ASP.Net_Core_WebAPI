using System;
using System.Collections.Generic;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class OrderDetail
{
    public byte[] OrderDetailId { get; set; } = null!;

    public byte[] OrderNumber { get; set; } = null!;

    public byte[] ProductId { get; set; } = null!;

    public int Quantity { get; set; }

    public byte[] UserId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public byte[] PaymentId { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public bool IsCancel { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
