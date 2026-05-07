using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class Rezervacija
    {
        [Key]
        private int rezervacijaId { get; set; }
        private DateOnly datumOd {  get; set; }
        private DateOnly datumDo { get; set; }
        private StatusZahtjeva status {  get; set; }
        private DateOnly datumZahtjeva { get; set; }
        [ForeignKey("Korisnik")]
        private int korisnikId { get; set; }

    }
}
