namespace WorkFlowEngine.Models.DTOs.Tasks
{
    public class ClientSubmitTaskDTO
    {
        public string taskGUID { get; set; }
        public ICollection<formVairablesDTO> varList { get; set; } = null;
    }
}
