using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [MinLength(5)]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public DateTime Birthday { get; set; }
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Rank Rank { get; set; }



    }
}
