using Database.Models.Enums;

namespace WorkFlowEngine.Models.DTOs.Account
{
    public class UserToClientDTO
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Gender Gender { get; set; }
        public string role { get; set; }
        public string token { get; set; }
    }
}
