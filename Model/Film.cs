using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalStore.Model;

public partial class Film
{
    public int Id { get; set; }
    [Display(Name="Film Name")]
    [Required]
    public string Name { get; set; } = null!;
    [Display(Name = "Description")]
    public string? Description { get; set; }

    public string? Synopsis { get; set; }
    [Required]
    public DateOnly ReleaseDate { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
