using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;

namespace laptopi.etf1.Models
{
    public class AdminModerator
    {
        [Key]
        public int adminModeratorId {  get; set; }
        public string ime {  get; set; }
        public string email { get; set; }
        public Uloga uloga { get; set; }
        
    }
}
