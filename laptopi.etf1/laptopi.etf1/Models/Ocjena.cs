using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class Ocjena
    {
        [Key]
        public int ocjenaId {  get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Ocjena mora biti između 1 i 5.")]
        public int vrijednost { get; set; }
        public DateOnly datumOcjenjivanja { get; set; }
        [ForeignKey("Artikal")]
        public int artikalId { get; set; }
        [ForeignKey("Korisnik")]
        public int korisnikId { get; set; }

    }
}
