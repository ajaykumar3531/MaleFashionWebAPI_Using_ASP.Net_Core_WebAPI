using System;
using System.Collections.Generic;

namespace MaleFashoin_WebAPI.DAL.MaleFashionDB;

public partial class Address
{
    public byte[] Id { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string State { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public string StatePinCode { get; set; } = null!;

    public string LandMark { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
