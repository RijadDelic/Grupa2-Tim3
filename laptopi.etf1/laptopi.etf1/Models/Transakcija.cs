using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class Transakcija
    {
        [Key]
        private int transakcijaId {  get; set; }
        [ForeignKey("Artikal")]
        private int artikalId { get; set; }
        [ForeignKey("Korisnik")]
        private int kupacId { get; set; }
        [ForeignKey("Korisnik")]
        private int prodavacId { get; set; }
        private TipTransakcije tipTransakcije { get; set; }
        private StatusZahtjeva status {  get; set; }
        private DateOnly datum {  get; set; }
        private double iznos {  get; set; }

    }
}
