using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class SlikaArtikla
    {
        [Key]
        public int slikaId {  get; set; }
        [Required]
        public string putanjaDatoteke { get; set; }
        [ForeignKey("Artikal")]
        [Required]
        public int artikalId {  get; set; }
    }
}
