using System;
using System.Collections.Generic;

namespace RentalStore.Model;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
    public string Note { get; set; }

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
