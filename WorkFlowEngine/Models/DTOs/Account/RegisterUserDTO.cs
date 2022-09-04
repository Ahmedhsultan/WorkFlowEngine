using Database.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace WorkFlowEngine.Models.DTOs.Account
{
    public class RegisterUserDTO
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required, MinLength(5)]
        public string userName { get; set; }
        [Required, MinLength(5)]
        public string password { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public Roles role { get; set; }
    }
}
