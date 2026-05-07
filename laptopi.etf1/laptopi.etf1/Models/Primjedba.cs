using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class Primjedba
    {
        [Key]
        private int primjedbaId { get; set; }
        private String sadrzaj {  get; set; }
        private DateOnly datumPrimjedbe {  get; set; }
        private bool validnost {  get; set; }
        [ForeignKey ("Artikal")]
        private int artikalId {  get; set; }
        [ForeignKey("Korisnik")]
        private int korisnikId { get; set; }

    }
}
