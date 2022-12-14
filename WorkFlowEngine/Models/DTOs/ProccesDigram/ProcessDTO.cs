using System.ComponentModel.DataAnnotations;

namespace WorkFlowEngine.Models.DTOs.ProccesDigram
{
    public class ProcessDTO
    {
        public string processId { get; set; }
        public string formId { get; set; } = "00000000-0000-0000-0000-000000000000";
        public bool start { get; set; } = false;
        public bool end { get; set; } = false;
        public List<string> outhUser { get; set; }
        [Required]
        public string nextProcessIdNo1 { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string nextProcessIdNo2 { get; set; } = "00000000-0000-0000-0000-000000000000";
    }
}
