using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;

namespace laptopi.etf1.Models
{
    public class AdminModerator
    {
        [Key]
        private int adminModeratorId {  get; set; }
        [Required]
        private string ime {  get; set; }
        [Required]
        private string email { get; set; }
        private Uloga uloga { get; set; }
        
    }
}
