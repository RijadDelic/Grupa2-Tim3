using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class SlikaArtikla
    {
        [Key]
        private int slikaId {  get; set; }
        [Required]
        private string putanjaDatoteke { get; set; }
        [ForeignKey("Artikal")]
        [Required]
        private int artikalId {  get; set; }
    }
}
