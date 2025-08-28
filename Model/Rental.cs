using System;
using System.Collections.Generic;

namespace RentalStore.Model;

public partial class Rental
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int FilmId { get; set; }

    public DateOnly RentalDate { get; set; }

    public DateOnly? DeadlineDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public virtual Film Film { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
