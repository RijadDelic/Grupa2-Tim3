using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class Ocjena
    {
        [Key]
        private int ojcenaId {  get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Ocjena mora biti između 1 i 5.")]
        private int vrijednost { get; set; }
        private DateOnly datumOcjenjivanja { get; set; }
        [ForeignKey("Artikal")]
        private int artikalId { get; set; }
        [ForeignKey("Korisnik")]
        private int korisnikId { get; set; }

    }
}
