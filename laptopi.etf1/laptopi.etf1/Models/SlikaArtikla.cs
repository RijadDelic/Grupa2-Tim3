using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class SlikaArtikla
    {
        [Key]
        public int slikaId {  get; set; }
        public string putanjaDatoteke { get; set; }
        [ForeignKey("Artikal")]
        public int artikalId {  get; set; }
    }
}
