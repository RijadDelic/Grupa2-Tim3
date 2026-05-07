using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;

namespace laptopi.etf1.Models
{
    public class Artikal
    {
        [Key]
        private int ArtikalId { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Naziv mora imati najmanje 5 karaktera.")]
        private string naziv {  get; set; }
        private string opis { get; set; }
        private Stanje stranje { get; set; }
        private DateOnly datumObjave { get; set; }
        private bool aktivnost {  get; set; }
        private double prosjecnaOcjena { get; set; }
        private Kategorija kategorija { get; set; }

    }
}
