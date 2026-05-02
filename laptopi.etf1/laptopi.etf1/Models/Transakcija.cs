using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class Transakcija
    {
        [Key]
        public int transakcijaId {  get; set; }
        [ForeignKey("Artikal")]
        public int artikalId { get; set; }
        [ForeignKey("Korisnik")]
        public int kupacId { get; set; }
        [ForeignKey("Korisnik")]
        public int prodavacId { get; set; }
        public TipTransakcije tipTransakcije { get; set; }
        public StatusZahtjeva status {  get; set; }
        public DateOnly datum {  get; set; }
        public double iznos {  get; set; }

    }
}
