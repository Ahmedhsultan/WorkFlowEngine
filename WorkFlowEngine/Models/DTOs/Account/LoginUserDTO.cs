using System.ComponentModel.DataAnnotations;

namespace WorkFlowEngine.Models.DTOs.Account
{
    public class LoginUserDTO
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
