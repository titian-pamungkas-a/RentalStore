using System;
using System.Collections.Generic;

namespace RentalStore.Model;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Address? Address { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    public string gender { get; set; } = "male";
}
