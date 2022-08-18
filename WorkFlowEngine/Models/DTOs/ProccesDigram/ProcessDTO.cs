using System.ComponentModel.DataAnnotations;

namespace WorkFlowEngine.Models.DTOs.ProccesDigram
{
    public class ProcessDTO
    {
        public string form { get; set; }
        public string script { get; set; }
        public bool start { get; set; }
        public bool end { get; set; }
        [Required]
        public List<string> usersOthenticated { get; set; }
        [Required]
        public string nextProcessIdNo1 { get; set; }
        public string nextProcessIdNo2 { get; set; }
    }
}
