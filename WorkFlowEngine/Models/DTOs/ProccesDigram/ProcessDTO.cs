using System.ComponentModel.DataAnnotations;

namespace WorkFlowEngine.Models.DTOs.ProccesDigram
{
    public class ProcessDTO
    {
        public Guid processId { get; set; }
        public Guid form { get; set; } = Guid.Empty;
        public Guid script { get; set; } = Guid.Empty;
        public bool start { get; set; } = false;
        public bool end { get; set; } = false;
        [Required]
        public List<string> usersOthenticated { get; set; }
        [Required]
        public Guid nextProcessIdNo1 { get; set; } = Guid.Empty;
        public Guid nextProcessIdNo2 { get; set; } = Guid.Empty;
    }
}
