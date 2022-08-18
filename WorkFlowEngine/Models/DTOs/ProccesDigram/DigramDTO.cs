using System.ComponentModel.DataAnnotations;

namespace WorkFlowEngine.Models.DTOs.ProccesDigram
{
    public class DigramDTO
    {
        public string userName { get; set; }
        [Required]
        public Guid digramId { get; set; }
        [Required]
        public string digramName { get; set; }
        [Required]
        public List<ProcessDTO> ProcessList { get; set; }
    }
}
