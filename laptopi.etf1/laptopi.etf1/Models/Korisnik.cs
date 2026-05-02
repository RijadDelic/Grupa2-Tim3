using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;

namespace laptopi.etf1.Models
{
    public class Korisnik
    {
        [Key]
        public int korisnikID { get; set; }
        public string ime {  get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public string sifra { get; set; }
        public Uloga uloga { get; set; }
        public DateOnly datumRegistracije { get; set; }
        public bool akrivan {  get; set; }
    }
}
