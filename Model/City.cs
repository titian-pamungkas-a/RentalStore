using System;
using System.Collections.Generic;

namespace RentalStore.Model;

public partial class City
{
    public int Id { get; set; }

    public int RegionId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Region Region { get; set; } = null!;
}
