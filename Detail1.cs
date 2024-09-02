using System.ComponentModel.DataAnnotations;

namespace CrudCore.Models
{
    public class Detail1
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
