using System.ComponentModel.DataAnnotations;
using TheMessage.Business.Interfaces.Entities;

namespace TheMessage.Business.Entities
{
    class User : IUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
