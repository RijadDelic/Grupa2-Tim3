using System.ComponentModel.DataAnnotations;

namespace laptopi.etf1.Models
{
    public class Ocjena
    {
        [Key]
        public int ocjenaId { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Ocjena mora biti između 1 i 5.")]
        public int vrijednost { get; set; }
        public DateOnly datumOcjenjivanja { get; set; }
        public string ocjenjenId { get; set; }   // korisnik koji je ocijenjen
        public string ocjenjivacId { get; set; } // korisnik koji ocjenjuje
    }
}