using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class Primjedba
    {
        [Key]
        public int primjedbaId { get; set; }
        public String sadrzaj {  get; set; }
        public DateOnly datumPrimjedbe {  get; set; }
        public bool validnost {  get; set; }
        [ForeignKey ("Artikal")]
        public int artikalId {  get; set; }
        [ForeignKey("Korisnik")]
        public int korisnikId { get; set; }

    }
}
