using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;

namespace laptopi.etf1.Models
{
    public class Artikal
    {
        [Key]
        public int ArtikalId { get; set; }
        public string naziv {  get; set; }
        public string opis { get; set; }
        public Stanje stranje { get; set; }
        public DateOnly datumObjave { get; set; }
        public bool aktivnost {  get; set; }
        public double prosjecnaOcjena { get; set; }
        public Kategorija kategorija { get; set; }

    }
}
