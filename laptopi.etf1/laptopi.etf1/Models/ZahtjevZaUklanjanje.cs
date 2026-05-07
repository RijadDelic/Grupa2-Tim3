using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class ZahtjevZaUklanjanje
    {
        [Key]
        private int zahtjevId {  get; set; }
        private string razlog {  get; set; }
        private DateOnly datumZahtjeva { get; set; }
        private StatusZahtjeva status { get; set; }
        [ForeignKey("Artikal")]
        private int artikalId { get; set; }
        [ForeignKey("Korisnik")]
        private int korisnikId {  get; set; }
        [ForeignKey("AdminModerator")]
        private int adminModeratorId { get; set; }
    }
}
