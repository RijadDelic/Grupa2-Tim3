using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class ZahtjevZaUklanjanje
    {
        [Key]
        public int zahtjevId {  get; set; }
        public string razlog {  get; set; }
        public DateOnly datumZahtjeva { get; set; }
        public StatusZahtjeva status { get; set; }
        [ForeignKey("Artikal")]
        public int artikalId { get; set; }
        [ForeignKey("Korisnik")]
        public int korisnikId {  get; set; }
        [ForeignKey("AdminModerator")]
        public int adminModeratorId { get; set; }
    }
}
