using System.ComponentModel.DataAnnotations;
namespace laptopi.etf1.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string ime { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Prezime mora imati najmanje 3 karaktera.")]
        public string prezime { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}