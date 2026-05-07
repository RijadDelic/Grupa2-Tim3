using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;

namespace laptopi.etf1.Models
{
    public class Korisnik //treba se naslijedit iz usera
    {
        [Key]
        public int korisnikID { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Naziv mora imati najmanje 3 karaktera.")]
        public string ime {  get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Naziv mora imati najmanje 5 karaktera.")]
        public string prezime { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@etf\.unsa\.ba$", ErrorMessage = "Email mora završavati sa @etf.unsa.ba")]
        public string email { get; set; }
        [Required]
        public string sifra { get; set; }
        public Uloga uloga { get; set; }
        public DateOnly datumRegistracije { get; set; }
        public bool akrivan {  get; set; }
    }
}
