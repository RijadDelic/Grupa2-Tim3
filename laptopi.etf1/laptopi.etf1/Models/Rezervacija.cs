using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class Rezervacija
    {
        [Key]
        public int rezervacijaId { get; set; }
        public DateOnly datumOd {  get; set; }
        public DateOnly datumDo { get; set; }
        public StatusZahtjeva status {  get; set; }
        public DateOnly datumZahtjeva { get; set; }
        [ForeignKey("Korisnik")]
        public int korisnikId { get; set; }

    }
}
