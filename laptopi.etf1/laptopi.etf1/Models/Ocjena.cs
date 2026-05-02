using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class Ocjena
    {
        [Key]
        public int ojcenaId {  get; set; }
        public int vrijednost { get; set; }
        public DateOnly datumOcjenjivanja { get; set; }
        [ForeignKey("Artikal")]
        public int artikalId { get; set; }
        [ForeignKey("Korisnik")]
        public int korisnikId { get; set; }

    }
}
