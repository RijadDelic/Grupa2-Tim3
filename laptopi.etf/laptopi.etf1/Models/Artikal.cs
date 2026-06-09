using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class Artikal
    {
        [Key]
        public int ArtikalId { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Naziv mora imati najmanje 5 karaktera.")]
        public string naziv { get; set; }
        public string opis { get; set; }
        public Stanje stranje { get; set; }
        public TipTransakcije tipTransakcije { get; set; }
        public DateOnly datumObjave { get; set; }
        public bool aktivnost { get; set; }
        public double prosjecnaOcjena { get; set; }
        public Kategorija kategorija { get; set; }
        public ICollection<SlikaArtikla> Slike { get; set; } = new List<SlikaArtikla>();

        [Range(0, double.MaxValue, ErrorMessage = "Cijena mora biti pozitivna.")]
        public decimal cijena { get; set; }
        public string? slikaPath { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }
}
