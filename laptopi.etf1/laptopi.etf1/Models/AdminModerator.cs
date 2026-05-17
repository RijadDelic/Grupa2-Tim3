using laptopi.etf1.Models.@enum;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace laptopi.etf1.Models
{
    public class AdminModerator : IdentityUser
    {
        [Key]
        public int adminModeratorId {  get; set; }
        [Required]
        public string ime {  get; set; }
        [Required]
        public string email { get; set; }
        public Uloga uloga { get; set; }
        
    }
}
