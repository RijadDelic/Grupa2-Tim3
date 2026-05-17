using laptopi.etf1.Models.@enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace laptopi.etf1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MinLength(3, ErrorMessage = "Naziv mora imati najmanje 3 karaktera.")]
        public string ime { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Prezime mora imati najmanje 3 karaktera.")]
        public string prezime { get; set; }
        public DateOnly datumRegistracije { get; set; }
        public bool aktivan { get; set; }
        public Uloga uloga { get; set; } 
    }
}
