using Database.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace WorkFlowEngine.Models.DTOs.Account
{
    public class RegisterUserDTO
    {
        [Required]
        public string fullName { get; set; }
        [Required, MinLength(5)]
        public string userName { get; set; }
        [Required, MinLength(5)]
        public string Password { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}
