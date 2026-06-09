using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopi.etf1.Models
{
    public class ZauzetDatum
    {
        [Key]
        public int zauzetDatumId { get; set; }

        [Required]
        public int artikalId { get; set; }

        [ForeignKey("artikalId")]
        public Artikal Artikal { get; set; }

        [Required]
        public DateOnly datum { get; set; }
    }
}
