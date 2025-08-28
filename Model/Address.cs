using System;
using System.Collections.Generic;

namespace RentalStore.Model;

public partial class Address
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int CityId { get; set; }

    public string Name { get; set; } = null!;

    public string? Num { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual User? User { get; set; }
}
