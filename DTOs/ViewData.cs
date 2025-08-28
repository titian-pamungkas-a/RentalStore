using System.ComponentModel.DataAnnotations;

namespace RentalStore.DTOs
{
    public class ViewData
    {
        [Display(Name = "FULL NAME")]
        public string Name { get; set; }
        [Display(Name = "PHYSICAL ADDRESS")]
        public string Address { get; set; }
        [Display(Name = "MOVIES RENTED")]
        public string Movies { get; set; }
        [Display(Name = "SALUTATION")]
        public string Salutation { get; set; }
    }
}
