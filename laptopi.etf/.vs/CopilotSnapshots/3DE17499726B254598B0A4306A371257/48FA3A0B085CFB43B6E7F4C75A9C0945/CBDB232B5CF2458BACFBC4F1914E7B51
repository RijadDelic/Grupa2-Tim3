using laptopi.etf1.Models.@enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime datumRegistracije { get; set; }
        public bool aktivan { get; set; } = true;
        public Uloga uloga { get; set; }
        [NotMapped]
        public string? profileImagePath { get; set; }
    }
}
